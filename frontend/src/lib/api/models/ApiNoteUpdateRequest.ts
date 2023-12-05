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
 * @interface ApiNoteUpdateRequest
 */
export interface ApiNoteUpdateRequest {
    /**
     * 
     * @type {string}
     * @memberof ApiNoteUpdateRequest
     */
    title?: string | null;
    /**
     * 
     * @type {string}
     * @memberof ApiNoteUpdateRequest
     */
    content?: string | null;
}

/**
 * Check if a given object implements the ApiNoteUpdateRequest interface.
 */
export function instanceOfApiNoteUpdateRequest(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ApiNoteUpdateRequestFromJSON(json: any): ApiNoteUpdateRequest {
    return ApiNoteUpdateRequestFromJSONTyped(json, false);
}

export function ApiNoteUpdateRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): ApiNoteUpdateRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'title': !exists(json, 'title') ? undefined : json['title'],
        'content': !exists(json, 'content') ? undefined : json['content'],
    };
}

export function ApiNoteUpdateRequestToJSON(value?: ApiNoteUpdateRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'title': value.title,
        'content': value.content,
    };
}
