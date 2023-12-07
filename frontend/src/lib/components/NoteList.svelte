<script lang="ts">
  import type { Note } from '$lib/types/Note';

  export let notes: Note[] = [];
</script>

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
        {note.content}
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
