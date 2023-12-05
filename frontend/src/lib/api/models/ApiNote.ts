/* tslint:disable */
/* eslint-disable */
/**
 * Note Keeper
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface ApiNote
 */
export interface ApiNote {
    /**
     * 
     * @type {string}
     * @memberof ApiNote
     */
    id?: string;
    /**
     * 
     * @type {string}
     * @memberof ApiNote
     */
    title?: string | null;
    /**
     * 
     * @type {string}
     * @memberof ApiNote
     */
    content?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof ApiNote
     */
    createdAt?: Date;
}

/**
 * Check if a given object implements the ApiNote interface.
 */
export function instanceOfApiNote(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ApiNoteFromJSON(json: any): ApiNote {
    return ApiNoteFromJSONTyped(json, false);
}

export function ApiNoteFromJSONTyped(json: any, ignoreDiscriminator: boolean): ApiNote {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': !exists(json, 'id') ? undefined : json['id'],
        'title': !exists(json, 'title') ? undefined : json['title'],
        'content': !exists(json, 'content') ? undefined : json['content'],
        'createdAt': !exists(json, 'createdAt') ? undefined : (new Date(json['createdAt'])),
    };
}

export function ApiNoteToJSON(value?: ApiNote | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'title': value.title,
        'content': value.content,
        'createdAt': value.createdAt === undefined ? undefined : (value.createdAt.toISOString()),
    };
}

