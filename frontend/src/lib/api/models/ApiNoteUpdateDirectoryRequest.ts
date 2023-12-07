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
 * @interface ApiNoteUpdateDirectoryRequest
 */
export interface ApiNoteUpdateDirectoryRequest {
    /**
     * 
     * @type {string}
     * @memberof ApiNoteUpdateDirectoryRequest
     */
    directoryName?: string | null;
}

/**
 * Check if a given object implements the ApiNoteUpdateDirectoryRequest interface.
 */
export function instanceOfApiNoteUpdateDirectoryRequest(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ApiNoteUpdateDirectoryRequestFromJSON(json: any): ApiNoteUpdateDirectoryRequest {
    return ApiNoteUpdateDirectoryRequestFromJSONTyped(json, false);
}

export function ApiNoteUpdateDirectoryRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): ApiNoteUpdateDirectoryRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'directoryName': !exists(json, 'directoryName') ? undefined : json['directoryName'],
    };
}

export function ApiNoteUpdateDirectoryRequestToJSON(value?: ApiNoteUpdateDirectoryRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'directoryName': value.directoryName,
    };
}
