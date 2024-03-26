<template>
  <VaButton
      @click="$refs.modal.show()">
    Add word
  </VaButton>
  <VaModal
      ref="modal"
      ok-text="Create"
      :before-ok="save"
      stateful>
    <h3 class="va-h3">
      Add new word
    </h3>
    <div class="modal-rows">
      <VaInput
          v-model="word.word"
          immediate-validation
          placeholder="Word"/>
      <VaInput
          v-model="word.transcription"
          placeholder="Transcription"/>
      <VaSelect
          v-model="word.language"
          placeholder="Select language"
          text-by="name"
          value-by="name"
          :options="languages"/>
      <div v-for="(errors, fieldName) in errors" :key="fieldName">
        <span v-if="errors.length > 0" class="va-title">{{ fieldName }}</span>
        <ul>
          <li v-for="error in errors" :key="error">
            {{ error }}
          </li>
        </ul>
      </div>
    </div>
  </VaModal>
</template>

<script lang="ts">

import {PropType, Ref, ref, toRefs} from "vue";
import axios, {AxiosError} from "axios";

class Word {
  id = null
  word = null
  transcription = null
  language = null
}

export default {
  props: {
    languages: {
      type: Array as PropType<string[]>,
      required: true
    }
  },
  emits: ['created'],
  setup(props: any, {emit}: any) {
    const errors = ref({ })
    const { languages } = toRefs(props);
    const word = ref(new Word())
    const save = async(hide: () => {}) => {
      try {
        const resp = await axios.post(`words`, word.value)
        errors.value = {}
        word.value.id = resp.data
        emit('created', word);
        hide()
        word.value = new Word()
      }
      catch (e: any) {
        if (e.response.status == 400) {
          errors.value = e.response.data.errors
        }
        else throw e;
      }
    }

    return {
      languages,
      word,
      save,
      errors
    };
  }
}
</script>

<style>
.modal-rows > div{
  display: flex;
  flex-flow: column;
  margin-bottom: 10px;
}
</style>