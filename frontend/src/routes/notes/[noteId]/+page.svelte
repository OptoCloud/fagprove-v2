<script lang="ts">
  import { page } from '$app/stores';
  import { noteApi } from '$lib/ApiSingleton';
  import { MapNoteFromApi } from '$lib/mappers/NoteMapper';
  import type { Note } from '$lib/types/Note';

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
</script>

<div class="p-8 flex flex-col gap-4">
  <!-- Header -->
  <div class="flex justify-between items-center">
    <h1 class="h1">Note</h1>
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
