import type { ApiNote } from "$lib/api";
import type { Note } from "$lib/types/Note";

export function MapNoteFromApi(apiNote: ApiNote | null | undefined): Note | null {
  if (!apiNote || !apiNote.id || !apiNote.title || !apiNote.content || !apiNote.createdAt) {
    return null;
  }

  return {
    id: apiNote.id,
    title: apiNote.title,
    content: apiNote.content,
    createdAt: new Date(apiNote.createdAt)
  };
}