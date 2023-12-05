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
 * @interface AccountLoginApiRequest
 */
export interface AccountLoginApiRequest {
    /**
     * 
     * @type {string}
     * @memberof AccountLoginApiRequest
     */
    usernameOrEmail?: string | null;
    /**
     * 
     * @type {string}
     * @memberof AccountLoginApiRequest
     */
    password?: string | null;
}

/**
 * Check if a given object implements the AccountLoginApiRequest interface.
 */
export function instanceOfAccountLoginApiRequest(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function AccountLoginApiRequestFromJSON(json: any): AccountLoginApiRequest {
    return AccountLoginApiRequestFromJSONTyped(json, false);
}

export function AccountLoginApiRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): AccountLoginApiRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'usernameOrEmail': !exists(json, 'usernameOrEmail') ? undefined : json['usernameOrEmail'],
        'password': !exists(json, 'password') ? undefined : json['password'],
    };
}

export function AccountLoginApiRequestToJSON(value?: AccountLoginApiRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'usernameOrEmail': value.usernameOrEmail,
        'password': value.password,
    };
}
