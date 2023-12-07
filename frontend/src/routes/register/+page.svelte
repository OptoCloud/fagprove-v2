<script lang="ts">
  import { focusTrap } from '@skeletonlabs/skeleton';
  import { goto } from '$app/navigation';
  import { AuthTokenStore } from '$lib/stores';
  import { userApi } from '$lib/ApiSingleton';

  // If the user is already logged in, redirect to home
  $: if ($AuthTokenStore) {
    goto('/home');
  }

  let username = '';
  let email = '';
  let password = '';

  let loading = false;
  $: disabled = !username || !email || !password || loading;

  async function handleSubmit() {
    if (disabled) return;

    try {
      loading = true;
      await userApi.userRegisterPost({
        username,
        email,
        password,
      });
      goto('/login');
    } catch (error) {
      console.log(error);
    } finally {
      loading = false;
    }
  }
</script>

<!-- Registration Form -->
<div class="responsive-card card p-8">
  <form class="flex flex-col space-y-4" on:submit|preventDefault={handleSubmit} use:focusTrap={true}>
    <!-- Title -->
    <h2>Register</h2>

    <!-- Username -->
    <label class="label">
      <span>Username</span>
      <input class="input" type="text" placeholder="Username" bind:value={username} />
    </label>

    <!-- Email -->
    <label class="label">
      <span>Email</span>
      <input class="input" type="email" placeholder="Email" bind:value={email} />

      <!-- Password -->
      <label class="label">
        <span>Password</span>
        <input class="input" type="password" placeholder="Password" bind:value={password} />
      </label>

      <!-- Submit -->
      <button type="submit" class="btn variant-filled w-full self-center" {disabled}> Register </button>
    </label>
  </form>
</div>
