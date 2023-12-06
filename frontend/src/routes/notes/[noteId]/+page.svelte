<script lang="ts">
  import { goto } from '$app/navigation';
  import { page } from '$app/stores';
  import { noteApi } from '$lib/ApiSingleton';
  import { MapNoteFromApi } from '$lib/mappers/NoteMapper';
  import type { Note } from '$lib/types/Note';
  import { getToastStore } from '@skeletonlabs/skeleton';

  const toastStore = getToastStore();

  const noteId = $page.params['noteId'];

  let note: Note | null = null;

  noteApi
    .noteIdGet(noteId)
    .then((response) => {
      note = MapNoteFromApi(response);
    })
    .catch((error) => {
      console.log(error);
    });

  function DeleteNote() {
    noteApi
      .noteIdDelete(noteId)
      .then((response) => {
        toastStore.trigger({
          message: 'Note deleted',
          background: 'variant-filled-success',
        });
        goto('/home');
      })
      .catch((error) => {
        toastStore.trigger({
          message: 'Error while deleting note',
          background: 'variant-filled-error',
        });
      });
  }
</script>

<div class="p-8 flex flex-col gap-4">
  <!-- Header -->
  <div class="flex justify-between items-center">
    <h1 class="h1">Note</h1>
    <div class="flex gap-4">
      {#if !!note}
        <a class="btn variant-filled-primary" href="/notes/{note.id}/edit"> Edit Note </a>
        <button class="btn variant-filled-error" on:click={DeleteNote}> Delete Note </button>
      {/if}
      <a class="btn variant-filled-tertiary" href="/home"> Back </a>
    </div>
  </div>

  <div class="card w-[80vw] p-8 flex flex-col gap-4 break-words">
    {#if !!note}
      <header class="card-header">
        <h2 class="h2">{note.title}</h2>
      </header>
      <section class="p-4 flex-1">
        {note.content}
      </section>
      <footer class="card-footer flex justify-end">
        <span>
          Created at {note.createdAt?.toLocaleString()}
        </span>
      </footer>
    {:else}
      <h1 class="h1">Note not found</h1>
    {/if}
  </div>
</div>
