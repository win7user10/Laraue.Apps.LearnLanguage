<template>
  <VaValue v-slot="v">
    <VaInput
        :model-value="value"
        @input="input($event.target.value)"
        :placeholder="placeholder"
    />
    <VaButton v-if="allowSave && canBeUpdated"
        icon="save"
        preset="plain"
        size="small"
        @click="save()" />
  </VaValue>
</template>

<script lang="ts">

import {computed, ref, toRefs} from "vue";

export default {
  props: {
    modelValue: String,
    placeholder: String,
    allowSave: Boolean
  },
  emits: ['update:modelValue', 'change'],
  setup(props: any, {emit}: any) {
    const { allowSave } = toRefs(props);
    const localValue = ref(props.modelValue);
    const save = async() => {
      emit('update:modelValue', localValue);
      emit('change', localValue);
    }

    const input = (value: string) => {
      localValue.value = value == '' ? undefined : value;
    }

    const canBeUpdated = computed(() => {
      return localValue.value != props.modelValue
    })

    return {
      value: localValue,
      placeholder: props.placeholder,
      save,
      canBeUpdated,
      input,
      allowSave
    };
  }
}
</script>