import type { ApiNote } from "$lib/api";
import type { Note } from "$lib/types/Note";

function isNullOrUndefined<T>(value: T | null | undefined): value is null | undefined {
  return value === null || value === undefined;
}

export function MapNoteFromApi(apiNote: ApiNote | null | undefined): Note | null {
  if (!apiNote || !apiNote.id || isNullOrUndefined(apiNote.title) || isNullOrUndefined(apiNote.content) || isNullOrUndefined(apiNote.directoryName) || isNullOrUndefined(apiNote.createdAt)) {
    return null;
  }

  return {
    id: apiNote.id,
    title: apiNote.title,
    content: apiNote.content,
    directoryName: apiNote.directoryName,
    createdAt: new Date(apiNote.createdAt)
  };
}