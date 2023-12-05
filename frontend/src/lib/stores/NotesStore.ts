import { writable, get } from 'svelte/store';
import type { Note } from '$lib/types/Note';

const internalStore = writable<Note[]>([]);
const { subscribe, set, update } = internalStore;

export const NotesStore = {
    subscribe,
    set,
    get: get(internalStore),
    add(note: Note) {
        update((store) => {
            store.push(note);
            return store;
        });
    },
    update(id: string, updater: (note: Note) => Note) {
        update((store) => {
            const index = store.findIndex((note) => note.id === id);
            if (index > -1) {
                store[index] = updater(store[index]);
            }
            return store;
        });
    },
    remove(id: string) {
        update((store) => {
            const index = store.findIndex((note) => note.id === id);
            if (index > -1) {
                store.splice(index, 1);
            }
            return store;
        });
    },
    clear() {
        set([]);
    }
};