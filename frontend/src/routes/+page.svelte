<script lang="ts">
  import { browser } from '$app/environment';
  import { goto } from '$app/navigation';
  import { PUBLIC_APP_NAME } from '$env/static/public';
  import { AuthTokenStore } from '$lib/stores';

  $: if (browser && !!$AuthTokenStore) {
    goto('/home');
  }
</script>

<div class="px-8 py-16">
  <div class="space-y-5">
    <h1 class="h1">Welcome to {PUBLIC_APP_NAME}!</h1>
    <p class="text-lg">
      {PUBLIC_APP_NAME} is a simple note taking app that allows you to create, edit, and delete notes.
    </p>
  </div>
</div>
