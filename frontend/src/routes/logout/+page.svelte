<script lang="ts">
  import { browser } from "$app/environment";
  import { goto } from "$app/navigation";
  import { AuthTokenStore } from "$lib/stores";


  $: if (browser) {
    AuthTokenStore.set(null);
    goto("/");
  }
</script>
