<script lang="ts">
  import { browser } from '$app/environment';
  import { goto } from '$app/navigation';
  import { page } from '$app/stores';
  import { noteApi } from '$lib/ApiSingleton';
  import type { ApiNoteUpdateRequest } from '$lib/api';
  import { MapNoteFromApi } from '$lib/mappers/NoteMapper';
  import { AuthTokenStore } from '$lib/stores';
  import { NotesStore } from '$lib/stores/NotesStore';
  import type { Note } from '$lib/types/Note';
  import { getToastStore } from '@skeletonlabs/skeleton';

  const toastStore = getToastStore();

  $: if (browser && !$AuthTokenStore) {
    toastStore.trigger({
      message: 'You are not logged in',
      background: 'variant-filled-error',
    });
    AuthTokenStore.set(null);
    goto('/login');
  }

  const noteId = $page.params['noteId'];

  let note: Note | null = null;
  let editing = false;
  let newTitle = '';
  let newContent = '';

  noteApi
    .noteIdGet(noteId)
    .then((response) => {
      note = MapNoteFromApi(response);
    })
    .catch((error) => {
      console.log(error);
    });

  function EditStart() {
    editing = true;
    newTitle = note?.title ?? '';
    newContent = note?.content ?? '';
  }
  function EditCancel() {
    editing = false;
    newTitle = '';
    newContent = '';
  }
  function EditApply() {
    if (!note || !editing) return;

    const titleUpdated = note?.title !== newTitle;
    const contentUpdated = note?.content !== newContent;

    if (!titleUpdated && !contentUpdated) {
      toastStore.trigger({
        message: 'Nothing to update',
        background: 'variant-filled-error',
      });
      editing = false;
      return;
    }

    noteApi
      .noteIdPut(noteId, {
        title: titleUpdated ? newTitle : null,
        content: contentUpdated ? newContent : null,
      })
      .then((response) => {
        note = MapNoteFromApi(response);
        toastStore.trigger({
          message: 'Note updated',
          background: 'variant-filled-success',
        });
      })
      .catch((error) => {
        toastStore.trigger({
          message: 'Error while updating note',
          background: 'variant-filled-error',
        });
      })
      .finally(() => {
        editing = false;
      });
  }
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
        {#if editing}
          <button class="btn variant-filled-primary" on:click={EditApply}> Save </button>
          <button class="btn variant-filled-error" on:click={EditCancel}> Cancel </button>
        {:else}
          <button class="btn variant-filled-primary" on:click={EditStart}> Edit </button>
        {/if}
        <button class="btn variant-filled-error" on:click={DeleteNote}> Delete Note </button>
      {/if}
      <a class="btn variant-filled-tertiary" href="/home"> Back </a>
    </div>
  </div>

  <div class="card w-[80vw] p-8 flex flex-col gap-4 break-words">
    {#if !!note}
      {#if editing}
        <header class="card-header">
          <div class="flex flex-col space-y-4">
            <label class="label">
              <h3 class="h3">Title</h3>
              <input class="input" type="text" bind:value={newTitle} />
            </label>
          </div>
        </header>
        <section class="p-4 flex-1">
          <label class="label">
            <h3 class="h3">Content</h3>
            <textarea class="textarea" bind:value={newContent} />
          </label>
        </section>
      {:else}
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
      {/if}
    {:else}
      <h1 class="h1">Note not found</h1>
    {/if}
  </div>
</div>
