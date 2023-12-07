<script lang="ts">
  import { browser } from '$app/environment';
  import { goto } from '$app/navigation';
  import { noteApi } from '$lib/ApiSingleton';
  import { AuthTokenStore } from '$lib/stores';
  import { NotesStore } from '$lib/stores/NotesStore';
  import { Accordion, AccordionItem, getModalStore, getToastStore } from '@skeletonlabs/skeleton';
  import { MapNoteFromApi } from '$lib/mappers/NoteMapper';
  import NoteList from '$lib/components/NoteList.svelte';
  import type { Note } from '$lib/types/Note';

  const toastStore = getToastStore();
  const modalStore = getModalStore();

  $: if (browser && !$AuthTokenStore) {
    toastStore.trigger({
      message: 'You are not logged in',
      background: 'variant-filled-error',
    });
    AuthTokenStore.set(null);
    goto('/');
  }

  // Get notes from API on page load
  noteApi
    .noteListGet()
    // If the request is successful, remap the response to Note model, and remove null values
    .then((response) => NotesStore.set(response.map(MapNoteFromApi).filter((note) => note !== null) as Note[]))
    // If there's an error, show a error message
    .catch((error) => {
      toastStore.trigger({
        message: 'Error while fetching notes',
        background: 'variant-filled-error',
      });
    });

  // Create a new note
  function AddNote() {
    modalStore.trigger({
      type: 'component',
      component: 'newNoteModal',
    });
  }

  let searchQuery = '';

  // For every note, combine title and content into a single string, and check if it contains the search query
  let searchResults: Note[] = [];
  $: if (searchQuery.length === 0) {
    searchResults = $NotesStore;
  } else {
    searchResults = $NotesStore.filter((note) => {
      const noteContent = note.title + note.content;

      return noteContent.toLowerCase().includes(searchQuery.toLowerCase());
    });
  }

  // Group notes by directoryName
  $: noteDirectories = searchResults.reduce((acc, note) => {
    const directoryName = note.directoryName ?? 'ROOT';

    const notes = acc.get(directoryName) ?? [];

    notes.push(note);

    acc.set(directoryName, notes);

    return acc;
  }, new Map<string, Note[]>());

  $: rootList = noteDirectories.get('ROOT') ?? [];
  $: otherLists = [...noteDirectories.entries()].filter(([directoryName]) => directoryName !== 'ROOT');
</script>

<div class="p-8 flex flex-col gap-4">
  <!-- Header -->
  <div class="flex justify-between items-center space-x-4 w-[80vw]">
    <h1 class="h1">Notes</h1>
    <input class="input" type="search" bind:value={searchQuery} placeholder="Search..." />
    <button class="btn variant-filled-primary" on:click={AddNote}> New Note </button>
  </div>

  <!-- List of note directories -->
  <div class="overflow-y-auto space-y-4">
    <!-- Root directory -->
    <NoteList notes={rootList} />

    <Accordion autocollapse>
      {#each otherLists as [directoryName, notes] (directoryName)}
        <AccordionItem class="card">
          <!-- Directory name -->
          <svelte:fragment slot="summary">
            <h2 class="h2">Directory - {directoryName}</h2>
          </svelte:fragment>

          <!-- List of notes -->
          <svelte:fragment slot="content">
            <NoteList {notes} />
          </svelte:fragment>
        </AccordionItem>
      {/each}
    </Accordion>
  </div>
</div>
