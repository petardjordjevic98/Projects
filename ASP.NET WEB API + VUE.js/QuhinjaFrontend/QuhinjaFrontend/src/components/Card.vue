<template>
  <div :id="id" class="card flex row" :draggable="draggable" @dragstart="dragStart" @dragover.stop>
    <slot />
  </div>
</template>
<script>
export default {
  props: ["id", "draggable"],
  methods: {
    dragStart: (e) => {
      const target = e.target;
      e.dataTransfer.setData("card_id", target.id);
    },
  },
};
</script>
