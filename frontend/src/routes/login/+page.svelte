<script lang="ts">
  import { focusTrap } from '@skeletonlabs/skeleton';
  import { goto } from '$app/navigation';
  import { AuthTokenStore } from '$lib/stores';
  import { userApi } from '$lib/ApiSingleton';

  // If the user is already logged in, redirect to home
  $: if ($AuthTokenStore) {
    goto('/home');
  }

  let usernameOrEmail = '';
  let password = '';

  let loading = false;
  $: disabled = !usernameOrEmail || !password || loading;

  async function handleSubmit() {
    if (disabled) return;

    try {
      loading = true;
      const response = await userApi.userLoginPut({
        usernameOrEmail,
        password,
      });
      AuthTokenStore.set(response.token ?? null);
	  if (!!response.token) {
      	goto('/home');
	  }
    } catch (error) {
		console.log(error);
    } finally {
      loading = false;
    }
  }
</script>

<!-- Login Form -->
<div class="responsive-card card p-8">
  <form
    class="flex flex-col space-y-4"
    on:submit|preventDefault={handleSubmit}
    use:focusTrap={true}
  >
    <!-- Title -->
    <h2>Login</h2>

    <!-- Username -->
	<label class="label">
	  <span>Username or Email</span>
	  <input
	  	class="input"
		type="text"
		placeholder="Username or Email"
		bind:value={usernameOrEmail}
	  />
	</label>

    <!-- Password -->
	<label class="label">
		<span>Password</span>
		<input
	  		class="input"
			type="password"
			placeholder="Password"
			bind:value={password}
		/>
	</label>

    <!-- Submit -->
    <button type="submit" class="btn variant-filled w-full self-center" {disabled}> Login </button>
  </form>
</div>