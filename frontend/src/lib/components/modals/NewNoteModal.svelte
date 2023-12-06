<script lang="ts">
  import { noteApi } from '$lib/ApiSingleton';
  import { NotesStore } from '$lib/stores/NotesStore';
  import { getModalStore, getToastStore } from '@skeletonlabs/skeleton';
  import { MapNoteFromApi } from '../../mappers/NoteMapper';
  import type { ApiNote } from '$lib/api';

  const toastStore = getToastStore();
  const modalStore = getModalStore();

  let title = 'New Note';
  let content = '';

  function HandleResponse(response: ApiNote) {
    let note = MapNoteFromApi(response);
    if (note) {
      NotesStore.add(note);
      toastStore.trigger({
        message: 'Note updated',
        background: 'variant-filled-success',
      });
    } else {
      toastStore.trigger({
        message: 'Error while updating note',
        background: 'variant-filled-error',
      });
    }
    modalStore.close();
  }

  function AddNote() {
    noteApi
      .createPost({
        title: title,
        content: content,
      })
      .then(HandleResponse)
      .catch((error) => {
        toastStore.trigger({
          message: 'Error while creating note',
          background: 'variant-filled-error',
        });
      });
  }
</script>

<div class="card p-4 w-[24rem] flex-col space-y-4">
  <h1 class="h1">New Note</h1>

  <div class="flex flex-col space-y-4">
    <label class="label">
      Title
      <input class="input" type="text" bind:value={title} />
    </label>

    <label class="label">
      Content
      <textarea class="textarea" bind:value={content} />
    </label>

    <button class="btn variant-filled-primary" on:click={AddNote}> Create Note </button>
  </div>
</div>
