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
 * @interface AccountLoginApiResponse
 */
export interface AccountLoginApiResponse {
    /**
     * 
     * @type {string}
     * @memberof AccountLoginApiResponse
     */
    token?: string | null;
}

/**
 * Check if a given object implements the AccountLoginApiResponse interface.
 */
export function instanceOfAccountLoginApiResponse(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function AccountLoginApiResponseFromJSON(json: any): AccountLoginApiResponse {
    return AccountLoginApiResponseFromJSONTyped(json, false);
}

export function AccountLoginApiResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): AccountLoginApiResponse {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'token': !exists(json, 'token') ? undefined : json['token'],
    };
}

export function AccountLoginApiResponseToJSON(value?: AccountLoginApiResponse | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'token': value.token,
    };
}
