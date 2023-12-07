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


import * as runtime from '../runtime';
import type {
  ApiNote,
  ApiNoteCreateRequest,
  ApiNoteUpdateDirectoryRequest,
  ApiNoteUpdateRequest,
} from '../models/index';
import {
    ApiNoteFromJSON,
    ApiNoteToJSON,
    ApiNoteCreateRequestFromJSON,
    ApiNoteCreateRequestToJSON,
    ApiNoteUpdateDirectoryRequestFromJSON,
    ApiNoteUpdateDirectoryRequestToJSON,
    ApiNoteUpdateRequestFromJSON,
    ApiNoteUpdateRequestToJSON,
} from '../models/index';

export interface NoteCreatePostRequest {
    apiNoteCreateRequest?: ApiNoteCreateRequest;
}

export interface NoteNoteIdDeleteRequest {
    noteId: string;
}

export interface NoteNoteIdDirectoryPutRequest {
    noteId: string;
    apiNoteUpdateDirectoryRequest?: ApiNoteUpdateDirectoryRequest;
}

export interface NoteNoteIdGetRequest {
    noteId: string;
}

export interface NoteNoteIdPutRequest {
    noteId: string;
    apiNoteUpdateRequest?: ApiNoteUpdateRequest;
}

/**
 * NoteApi - interface
 * 
 * @export
 * @interface NoteApiInterface
 */
export interface NoteApiInterface {
    /**
     * 
     * @param {ApiNoteCreateRequest} [apiNoteCreateRequest] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteCreatePostRaw(requestParameters: NoteCreatePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>>;

    /**
     */
    noteCreatePost(apiNoteCreateRequest?: ApiNoteCreateRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote>;

    /**
     * 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteListGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ApiNote>>>;

    /**
     */
    noteListGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ApiNote>>;

    /**
     * 
     * @param {string} noteId 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteNoteIdDeleteRaw(requestParameters: NoteNoteIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<string>>;

    /**
     */
    noteNoteIdDelete(noteId: string, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<string>;

    /**
     * 
     * @param {string} noteId 
     * @param {ApiNoteUpdateDirectoryRequest} [apiNoteUpdateDirectoryRequest] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteNoteIdDirectoryPutRaw(requestParameters: NoteNoteIdDirectoryPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>>;

    /**
     */
    noteNoteIdDirectoryPut(noteId: string, apiNoteUpdateDirectoryRequest?: ApiNoteUpdateDirectoryRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote>;

    /**
     * 
     * @param {string} noteId 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteNoteIdGetRaw(requestParameters: NoteNoteIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>>;

    /**
     */
    noteNoteIdGet(noteId: string, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote>;

    /**
     * 
     * @param {string} noteId 
     * @param {ApiNoteUpdateRequest} [apiNoteUpdateRequest] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoteApiInterface
     */
    noteNoteIdPutRaw(requestParameters: NoteNoteIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>>;

    /**
     */
    noteNoteIdPut(noteId: string, apiNoteUpdateRequest?: ApiNoteUpdateRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote>;

}

/**
 * 
 */
export class NoteApi extends runtime.BaseAPI implements NoteApiInterface {

    /**
     */
    async noteCreatePostRaw(requestParameters: NoteCreatePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/create`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: ApiNoteCreateRequestToJSON(requestParameters.apiNoteCreateRequest),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ApiNoteFromJSON(jsonValue));
    }

    /**
     */
    async noteCreatePost(apiNoteCreateRequest?: ApiNoteCreateRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote> {
        const response = await this.noteCreatePostRaw({ apiNoteCreateRequest: apiNoteCreateRequest }, initOverrides);
        return await response.value();
    }

    /**
     */
    async noteListGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ApiNote>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/list`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ApiNoteFromJSON));
    }

    /**
     */
    async noteListGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ApiNote>> {
        const response = await this.noteListGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async noteNoteIdDeleteRaw(requestParameters: NoteNoteIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<string>> {
        if (requestParameters.noteId === null || requestParameters.noteId === undefined) {
            throw new runtime.RequiredError('noteId','Required parameter requestParameters.noteId was null or undefined when calling noteNoteIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/{noteId}`.replace(`{${"noteId"}}`, encodeURIComponent(String(requestParameters.noteId))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        if (this.isJsonMime(response.headers.get('content-type'))) {
            return new runtime.JSONApiResponse<string>(response);
        } else {
            return new runtime.TextApiResponse(response) as any;
        }
    }

    /**
     */
    async noteNoteIdDelete(noteId: string, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<string> {
        const response = await this.noteNoteIdDeleteRaw({ noteId: noteId }, initOverrides);
        return await response.value();
    }

    /**
     */
    async noteNoteIdDirectoryPutRaw(requestParameters: NoteNoteIdDirectoryPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>> {
        if (requestParameters.noteId === null || requestParameters.noteId === undefined) {
            throw new runtime.RequiredError('noteId','Required parameter requestParameters.noteId was null or undefined when calling noteNoteIdDirectoryPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/{noteId}/directory`.replace(`{${"noteId"}}`, encodeURIComponent(String(requestParameters.noteId))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ApiNoteUpdateDirectoryRequestToJSON(requestParameters.apiNoteUpdateDirectoryRequest),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ApiNoteFromJSON(jsonValue));
    }

    /**
     */
    async noteNoteIdDirectoryPut(noteId: string, apiNoteUpdateDirectoryRequest?: ApiNoteUpdateDirectoryRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote> {
        const response = await this.noteNoteIdDirectoryPutRaw({ noteId: noteId, apiNoteUpdateDirectoryRequest: apiNoteUpdateDirectoryRequest }, initOverrides);
        return await response.value();
    }

    /**
     */
    async noteNoteIdGetRaw(requestParameters: NoteNoteIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>> {
        if (requestParameters.noteId === null || requestParameters.noteId === undefined) {
            throw new runtime.RequiredError('noteId','Required parameter requestParameters.noteId was null or undefined when calling noteNoteIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/{noteId}`.replace(`{${"noteId"}}`, encodeURIComponent(String(requestParameters.noteId))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ApiNoteFromJSON(jsonValue));
    }

    /**
     */
    async noteNoteIdGet(noteId: string, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote> {
        const response = await this.noteNoteIdGetRaw({ noteId: noteId }, initOverrides);
        return await response.value();
    }

    /**
     */
    async noteNoteIdPutRaw(requestParameters: NoteNoteIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ApiNote>> {
        if (requestParameters.noteId === null || requestParameters.noteId === undefined) {
            throw new runtime.RequiredError('noteId','Required parameter requestParameters.noteId was null or undefined when calling noteNoteIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/Note/{noteId}`.replace(`{${"noteId"}}`, encodeURIComponent(String(requestParameters.noteId))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ApiNoteUpdateRequestToJSON(requestParameters.apiNoteUpdateRequest),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ApiNoteFromJSON(jsonValue));
    }

    /**
     */
    async noteNoteIdPut(noteId: string, apiNoteUpdateRequest?: ApiNoteUpdateRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ApiNote> {
        const response = await this.noteNoteIdPutRaw({ noteId: noteId, apiNoteUpdateRequest: apiNoteUpdateRequest }, initOverrides);
        return await response.value();
    }

}
