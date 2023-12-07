<script lang="ts">
  import { browser } from '$app/environment';
  import { goto } from '$app/navigation';
  import { noteApi } from '$lib/ApiSingleton';
  import { AuthTokenStore } from '$lib/stores';
  import { NotesStore } from '$lib/stores/NotesStore';
  import { Accordion, AccordionItem, getModalStore, getToastStore } from '@skeletonlabs/skeleton';
  import { MapNoteFromApi } from '$lib/mappers/NoteMapper';
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
    .listGet()
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

  // Group notes by directoryName
  $: noteDirectories = $NotesStore.reduce((acc, note) => {
    const directoryName = note.directoryName ?? 'ROOT';

    const notes = acc.get(directoryName) ?? [];

    notes.push(note);

    acc.set(directoryName, notes);

    return acc;
  }, new Map<string, Note[]>());
</script>

<div class="p-8 flex flex-col gap-4">
  <!-- Header -->
  <div class="flex justify-between items-center w-[80vw]">
    <h1 class="h1">Notes</h1>
    <button class="btn variant-filled-primary" on:click={AddNote}> New Note </button>
  </div>

  <!-- List of note directories -->
  <div class="overflow-y-auto h-[60vh]">
    <Accordion autocollapse>
      {#each noteDirectories as [directoryName, notes] (directoryName)}
        <AccordionItem class="card">
          <!-- Directory name -->
          <svelte:fragment slot="summary">
            <h2 class="h2">{directoryName}</h2>
          </svelte:fragment>

          <!-- List of notes -->
          <svelte:fragment slot="content">
            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
              {#each notes as note (note.id)}
                <!-- Note card -->
                <a class="card break-words flex flex-col" href="/notes/{note.id}">
                  <!-- Note title -->
                  <header class="card-header">
                    <h2 class="h2">{note.title}</h2>
                  </header>

                  <!-- Note content -->
                  <section class="p-4 flex-1">
                    {note.content.length > 200 ? note.content.substring(0, 200) + '...' : note.content}
                  </section>

                  <!-- Note footer -->
                  <footer class="card-footer flex justify-end">
                    <span>
                      Created at {note.createdAt?.toLocaleString()}
                    </span>
                  </footer>
                </a>
              {/each}
            </div>
          </svelte:fragment>
        </AccordionItem>
      {/each}
    </Accordion>
  </div>
</div>
