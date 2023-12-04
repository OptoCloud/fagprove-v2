<script lang="ts">
	import { browser } from "$app/environment";
	import { goto } from "$app/navigation";
	import { AuthTokenStore } from "$lib/stores";


    if (browser && !$AuthTokenStore) {
        goto("/login");
    }
</script>

<div class="responsive-card card p-8">
    <h1> Home </h1>
</div>