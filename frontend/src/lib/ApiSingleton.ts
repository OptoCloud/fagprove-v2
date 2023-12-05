import { AuthTokenStore } from './stores';
import { browser } from '$app/environment';
import {
  Configuration,
  NoteApi,
  UserApi,
} from '$lib/api';
import { PUBLIC_BACKEND_API_BASE_URL } from '$env/static/public';

export const DefaultApiConfiguration = new Configuration({
  basePath: PUBLIC_BACKEND_API_BASE_URL,
  credentials: 'include',
  apiKey: (key) => {
    if (!browser || key !== 'Authorization') return '';

    const session = AuthTokenStore.get();
    if (!session) return '';

    return `Bearer ${session}`;
  },
});

export const noteApi = new NoteApi(DefaultApiConfiguration);
export const userApi = new UserApi(DefaultApiConfiguration);