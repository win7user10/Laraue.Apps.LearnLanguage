<template>
  <div class="main-view">
    <div class="main-view-content">

      <div class="mb-12">
        <div>
          <VaInput
              v-model="search"
              placeholder="Search Word"/>
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

        <template #cell(actions)="{ rowIndex, row, isExpanded }">
          <VaButton
              :icon="isExpanded ? 'va-arrow-up': 'va-arrow-down'"
              preset="secondary"
              class="w-full"
              @click="row.toggleRowDetails()"
          />
          <VaButton
              preset="plain"
              icon="delete"
              class="ml-3"
          />
        </template>

        <template #expandableRow="{ rowData }">

          <div v-for="meaning in rowData.meanings" class="meaning">
            <VaAlert
                color="info"
                border="top">
              <template #title>
                <div class="meaning-title">
                  <h4>Meaning #{{ meaning.id }}</h4>
                  <div class="meaning-selects">
                    <VaSelect
                        v-model="meaning.partsOfSpeech"
                        label="Parts of speech"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="partsOfSpeech"
                        multiple
                    />
                    <VaSelect
                        v-model="meaning.topics"
                        label="Topics"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="topics"
                        multiple
                    />
                    <VaSelect
                        v-model="meaning.level"
                        label="CEFR level"
                        text-by="name"
                        value-by="name"
                        clearable
                        :options="cefrLevels"
                    />
                  </div>
                </div>
              </template>
              <VaDivider />
              <table class="va-table" style="width: 100%">
                <thead>
                <tr>
                  <th>Id</th>
                  <th>Language</th>
                  <th>Text</th>
                </tr>
                </thead>
                <tbody>
                <tr
                    v-for="translation in meaning.translations"
                    :key="translation.language">
                  <td>{{ translation.id }}</td>
                  <td>{{ translation.language }}</td>
                  <td>
                    <EditableField
                        :model-value="translation.text"
                        placeholder="Add translation"
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
import {onMounted, ref, watch} from "vue";
import axios from "axios";
import {DataTableColumnSource} from "vuestic-ui";
import EditableField from "@/components/EditableField.vue"; // @ is an alias to /src

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

interface Meaning {
  id: number;
  meaning: string | null;
  cefrLevel: string | null;
  topics: string[]
  partsOfSpeech: string[]
  translations: Translation[]
}

interface Translation {
  id: number;
  language: string;
  text: string;
}

interface DictionaryItem{
  name: string;
}

export default {
  components: {EditableField},
  setup(){
    const isLoading = ref(false);
    const items = ref(new Array<Word>())

    const languages = ref(new Array<DictionaryItem>())
    const partsOfSpeech = ref(new Array<DictionaryItem>())
    const topics = ref(new Array<DictionaryItem>())
    const cefrLevels = ref(new Array<DictionaryItem>())

    const page = ref(-1)
    const perPage = 20
    const search = ref('');

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
            search: search.value
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
                cefrLevel: m.cefrLevel,
                topics: m.topics,
                partsOfSpeech: m.partsOfSpeech,
                translations: languages.value
                  .filter(l => l.name != i.language)
                  .map(t => {
                    return {
                      language: t.name,
                      text: m.translations.find(x => x.language == t.name)?.text
                    }
                  })
              }
            })
          }
        })
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

    watch(search, async () => {
      page.value = -1;
      items.value = [];
    })

    return {
      items,
      columns,
      loadNextItems,
      search,
      languages,
      partsOfSpeech,
      topics,
      cefrLevels,
      updateWord
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