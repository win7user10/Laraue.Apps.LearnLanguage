<template>
  <VaValue v-slot="v">
    <VaInput
        :model-value="localValue"
        @input="input($event.target.value)"
        :placeholder="placeholder"
    >
      <template #appendInner>
        <VaButton
            v-if="hasUpperCaseWarn"
            icon="warning"
            color="secondary"
            preset="plain"
            @click="toLowerCase"
        />
        <VaButton
            v-if="allowSave && canBeUpdated"
            icon="save"
            preset="plain"
            @click="save" />
      </template>
    </VaInput>
  </VaValue>
</template>

<script lang="ts">

import {computed, ref, toRefs, watch} from "vue";

export default {
  props: {
    modelValue: String,
    placeholder: String,
    allowSave: Boolean,
    upperCaseWarn: Boolean
  },
  emits: ['update:modelValue', 'change'],
  setup(props: any, {emit}: any) {
    const { allowSave, modelValue, upperCaseWarn } = toRefs(props);
    const localValue = ref(props.modelValue);
    const isLastChangeMadeOutside = ref(false)

    const save = async() => {
      emit('update:modelValue', localValue.value);
      emit('change', localValue.value);
      isLastChangeMadeOutside.value = false;
    }

    const input = (value: string) => {
      localValue.value = value == '' ? undefined : value;
    }

    const canBeUpdated = computed(() => {
      return isLastChangeMadeOutside.value || localValue.value != modelValue.value
    })

    const hasUpperCaseWarn = computed(() => {
      return upperCaseWarn.value
          && localValue.value
          && localValue.value.charAt(0).toUpperCase() == localValue.value.charAt(0)
    })

    const toLowerCase = () => {
      
    }

    watch(modelValue, (newValue, oldValue) => {
      if (newValue != localValue.value){
        localValue.value = newValue
        isLastChangeMadeOutside.value = true
      }
    });

    return {
      localValue: localValue,
      placeholder: props.placeholder,
      save,
      canBeUpdated,
      input,
      allowSave,
      hasUpperCaseWarn,
      toLowerCase
    };
  }
}
</script>