<template>
  <div class="main-view">
    <div class="main-view-content">

      <div class="mb-12">
        <div>
          <VaInput
              v-model="searchFilter"
              placeholder="Search Word"
              @update:modelValue="updateFilters"/>
          <VaSelect
              v-model="topicsFilter"
              text-by="name"
              value-by="name"
              clearable
              :options="topics"
              multiple
              placeholder="Topics"
              @update:modelValue="updateFilters"/>
          <CreateWordModal
              @created="updateFilters"
              :languages="languages"
          ></CreateWordModal>
        </div>
      </div>

      <VaDataTable
          :items="items"
          :columns="columns"
          sticky-header
          sticky-footer
          height="700px"
          :scroll-bottom-margin="20"
          @scroll:bottom="loadNextItems">

        <template #cell(meanings)="{source}">
          {{ source.length }}
        </template>

        <template #cell(transcription)="{rowData}">
          <EditableField
              v-model="rowData.transcription"
              @change="updateWord(rowData)"
              placeholder="Add transcription"
          ></EditableField>
        </template>

        <template #cell(actions)="{ rowIndex, row, isExpanded, rowData }">
          <VaButton
              :icon="isExpanded ? 'va-arrow-up': 'va-arrow-down'"
              preset="secondary"
              @click="row.toggleRowDetails()"
          />
          <VaButton
              icon="add"
              preset="plain"
              class="ml-3"
              @click="addMeaning(rowData)"
          />
          <VaButton
              preset="plain"
              icon="delete"
              class="ml-3"
              @click="deleteWord(rowIndex)"
          />
        </template>

        <template #expandableRow="{ rowData }">
          <div v-for="(meaning, i) in rowData.meanings" class="meaning">
            <VaAlert
                color="info"
                border="top">
              <template #title>
                <div class="meaning-title">
                  <div style="display: flex; justify-content: space-between">
                    <h4>Meaning #{{ meaning.id }}</h4>
                    <VaButton
                        preset="plain"
                        icon="delete"
                        class="ml-3"
                        @click="deleteMeaning(rowData, i)"
                    />
                  </div>
                  <div class="meaning-selects">
                    <VaSelect
                        v-model="meaning.partsOfSpeech"
                        label="Parts of speech"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="partsOfSpeech"
                        multiple
                        @update:modelValue="updateMeaning(rowData.id, meaning)"
                    />
                    <VaSelect
                        v-model="meaning.topics"
                        label="Topics"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="topics"
                        multiple
                        @update:modelValue="updateMeaning(rowData.id, meaning)"
                    />
                    <VaSelect
                        v-model="meaning.level"
                        label="CEFR level"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="cefrLevels"
                        :clearValue="null!"
                        @update:modelValue="updateMeaning(rowData.id, meaning)"
                    />
                  </div>
                </div>
              </template>
              <VaDivider />
              <table class="va-table" style="width: 100%">
                <thead>
                <tr>
                  <th>Language</th>
                  <th>Text</th>
                </tr>
                </thead>
                <tbody>
                <tr
                    v-for="translation in meaning.translations"
                    :key="translation.language">
                  <td>{{ translation.language }}</td>
                  <td>
                    <EditableField
                        v-model="translation.text"
                        :allow-save="!!meaning.id"
                        placeholder="Add translation"
                        @change="updateTranslation(rowData.id, meaning.id, translation)"
                    ></EditableField>
                  </td>
                </tr>
                </tbody>
              </table>
            </VaAlert>
          </div>

        </template>

      </VaDataTable>
    </div>
  </div>
</template>

<script lang="ts">
import {onMounted, ref} from "vue";
import axios from "axios";
import {DataTableColumnSource} from "vuestic-ui";
import EditableField from "@/components/EditableField.vue";
import CreateWordModal from "@/components/CreateWordModal.vue"; // @ is an alias to /src

interface Result<T> {
  page: number;
  perPage: number;
  data: T[]
}

interface Word {
  id: number;
  word: string,
  language: string,
  transcription: string;
  meanings: Meaning[]
}

class Meaning {
  id: number | null = null;
  meaning: string | null = null;
  level: string | null = null;
  topics: string [] = []
  partsOfSpeech: string[] = []
  translations: Translation[] = []
}

class Translation {
  language: string = "";
  text: string | null | undefined = null;
}

interface DictionaryItem{
  name: string;
}

export default {
  components: {CreateWordModal, EditableField},
  setup(){
    const isLoading = ref(false);
    const items = ref(new Array<Word>())

    const languages = ref(new Array<DictionaryItem>())
    const partsOfSpeech = ref(new Array<DictionaryItem>())
    const topics = ref(new Array<DictionaryItem>())
    const cefrLevels = ref(new Array<DictionaryItem>())

    const page = ref(-1)
    const perPage = 20
    const searchFilter = ref('');
    const topicsFilter = ref(new Array<string>());

    const withLoader = async (func: () => Promise<any>) => {
      try {
        return await func();
      } finally {
        isLoading.value = false;
      }
    }

    const loadAsync = async () => {
      return await withLoader(async() => {
        const { data } = await axios.get<Result<Word>>('words', {
          params: {
            page: page.value,
            perPage: perPage,
            search: searchFilter.value,
            topics: topicsFilter.value
          } });
        return data.data.map(i => {
          return {
            id: i.id,
            language: i.language,
            word: i.word,
            transcription: i.transcription,
            meanings: i.meanings.map(m => {
              return {
                id: m.id,
                meaning: m.meaning,
                level: m.level,
                topics: m.topics,
                partsOfSpeech: m.partsOfSpeech,
                translations: getMeaningTranslations(i.language, m.translations)
              }
            })
          }
        })
      })
    }

    const getMeaningTranslations = (meaningLanguage: string, existingTranslations: Translation[]) => {
      return languages.value
          .filter(l => l.name != meaningLanguage)
          .map(t => {
            const translation = new Translation()
            translation.language = t.name;
            translation.text = existingTranslations.find(x => x.language == t.name)?.text
            return translation
          })
    }

    const loadNextItems = async () => {
      page.value += 1;
      const result = await loadAsync();
      items.value.push(...result);
    }

    const columns: DataTableColumnSource[] = [
      {
        key: "id",
        label: "Id"
      },
      {
        key: "word",
        label: "Word"
      },
      {
        key: "language",
        label: "Language"
      },
      {
        key: "transcription",
        label: "Transcription"
      },
      {
        key: "meanings",
        label: "Meanings count"
      },
      {
        key: "actions",
        width: 80
      }
    ]

    const updateWord = (word: Word) => {
      return axios.post('words', word)
    }

    const deleteWord = async (wordIndex: number) => {
      const word = items.value[wordIndex]
      await axios.delete(`words/${word.id}`)
      items.value.splice(wordIndex, 1)
    }

    const updateMeaning = async (wordId: number, meaning: Meaning) => {
      const resp = await axios.post(`words/${wordId}/meanings`, meaning)
      meaning.id = resp.data
    }

    const addMeaning = (word: Word) => {
      const meaning = new Meaning()
      meaning.translations = getMeaningTranslations(word.language, []);
      word.meanings.push(meaning)
    }

    const deleteMeaning = async (word: Word, index: number) => {
      const meaning = word.meanings[index]
      if (meaning.id)
        await axios.delete(`words/${word.id}/meanings/${meaning.id}`)
      word.meanings.splice(index, 1)
    }

    const updateTranslation = (wordId: number, meaningId: number, translation: Translation) => {
      return translation.text
        ? axios.post(`words/${wordId}/meanings/${meaningId}/translations`, translation)
        : axios.delete(`words/${wordId}/meanings/${meaningId}/translations/${translation.language}`)
    }

    onMounted(async () => {
      let resp = await withLoader(() => axios.get('dictionaries/languages'));
      languages.value = resp.data;

      resp = await withLoader(() => axios.get('dictionaries/parts-of-speeches'));
      partsOfSpeech.value = resp.data;

      resp = await withLoader(() => axios.get('dictionaries/topics'));
      topics.value = resp.data;

      resp = await withLoader(() => axios.get('dictionaries/cefr-levels'));
      cefrLevels.value = resp.data;
    });

    const updateFilters = async () => {
      page.value = -1;
      items.value = [];
    }

    return {
      items,
      columns,
      loadNextItems,
      searchFilter,
      topicsFilter,
      languages,
      partsOfSpeech,
      topics,
      cefrLevels,
      updateWord,
      updateMeaning,
      updateTranslation,
      updateFilters,
      addMeaning,
      deleteMeaning,
      deleteWord
    }
  }
}
</script>

<style>
.main-view {
  display: flex;
  align-items: center;
  flex-flow: column;
  width: 99vw;
}
.main-view-content{
  margin: 40px;
  width: 850px;
  align-items: center;
  flex-flow: column;
}
.meaning{
  margin: 10px;
}
.meaning-title{
  justify-content: center;
}
.va-data-table__table td, .va-data-table__table .va-button{
  vertical-align: baseline !important;
}
.meaning-selects{
  margin-top: 10px;
}
</style>