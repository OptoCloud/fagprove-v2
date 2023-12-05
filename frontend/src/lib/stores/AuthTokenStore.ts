import { browser } from '$app/environment';
import { writable, type Updater } from 'svelte/store';

const StorageKey = 'authToken';

function getFromStorage(): string | null {
  // Security measure: token should only persist in browser
  if (!browser) return null;

  return localStorage?.getItem(StorageKey);
}

function setStorage(value: string | null) {
  if (!browser) return;

  try {
    if (value) {
      localStorage?.setItem(StorageKey, value);
    } else {
      localStorage?.removeItem(StorageKey);
    }
  } catch (e) {
    console.error('[sessionTokenStore.ts] Error setting session token', e);
    try {
      localStorage?.removeItem(StorageKey);
    } catch {
      // ignore
    }
  }
}

const { subscribe, set, update } = writable<string | null>(getFromStorage());

export const AuthTokenStore = {
  subscribe,
  get: getFromStorage,
  set(value: string | null) {
    // Security measure: token should only persist in browser
    if (!browser) return;

    setStorage(value);
    set(value);
  },
  update(updater: Updater<string | null>) {
    // Security measure: token should only persist in browser
    if (!browser) return;

    update((current) => {
      const value = updater(current);
      setStorage(value);
      return value;
    });
  },
};