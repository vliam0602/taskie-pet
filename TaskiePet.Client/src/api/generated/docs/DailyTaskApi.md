# DailyTaskApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiDailyTaskGet**](#apidailytaskget) | **GET** /api/DailyTask | |
|[**apiDailyTaskMarkCompletedTaskIdPut**](#apidailytaskmarkcompletedtaskidput) | **PUT** /api/DailyTask/mark-completed/{taskId} | |
|[**apiDailyTaskPost**](#apidailytaskpost) | **POST** /api/DailyTask | |
|[**apiDailyTaskTaskIdGet**](#apidailytasktaskidget) | **GET** /api/DailyTask/{taskId} | |
|[**apiDailyTaskTaskIdPut**](#apidailytasktaskidput) | **PUT** /api/DailyTask/{taskId} | |

# **apiDailyTaskGet**
> ApiResponseOfIEnumerableOfDailyTask apiDailyTaskGet()


### Example

```typescript
import {
    DailyTaskApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DailyTaskApi(configuration);

let userId: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiDailyTaskGet(
    userId
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **userId** | [**string**] |  | (optional) defaults to undefined|


### Return type

**ApiResponseOfIEnumerableOfDailyTask**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiDailyTaskMarkCompletedTaskIdPut**
> ApiResponseOfDailyTask apiDailyTaskMarkCompletedTaskIdPut(dailyTaskMarkCompletedRequest)


### Example

```typescript
import {
    DailyTaskApi,
    Configuration,
    DailyTaskMarkCompletedRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new DailyTaskApi(configuration);

let taskId: string; // (default to undefined)
let dailyTaskMarkCompletedRequest: DailyTaskMarkCompletedRequest; //

const { status, data } = await apiInstance.apiDailyTaskMarkCompletedTaskIdPut(
    taskId,
    dailyTaskMarkCompletedRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dailyTaskMarkCompletedRequest** | **DailyTaskMarkCompletedRequest**|  | |
| **taskId** | [**string**] |  | defaults to undefined|


### Return type

**ApiResponseOfDailyTask**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiDailyTaskPost**
> ApiResponseOfDailyTask apiDailyTaskPost(dailyTaskCreateRequest)


### Example

```typescript
import {
    DailyTaskApi,
    Configuration,
    DailyTaskCreateRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new DailyTaskApi(configuration);

let dailyTaskCreateRequest: DailyTaskCreateRequest; //

const { status, data } = await apiInstance.apiDailyTaskPost(
    dailyTaskCreateRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dailyTaskCreateRequest** | **DailyTaskCreateRequest**|  | |


### Return type

**ApiResponseOfDailyTask**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiDailyTaskTaskIdGet**
> ApiResponseOfDailyTask apiDailyTaskTaskIdGet()


### Example

```typescript
import {
    DailyTaskApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DailyTaskApi(configuration);

let taskId: string; // (default to undefined)

const { status, data } = await apiInstance.apiDailyTaskTaskIdGet(
    taskId
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **taskId** | [**string**] |  | defaults to undefined|


### Return type

**ApiResponseOfDailyTask**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiDailyTaskTaskIdPut**
> ApiResponseOfDailyTask apiDailyTaskTaskIdPut(dailyTaskUpdateRequest)


### Example

```typescript
import {
    DailyTaskApi,
    Configuration,
    DailyTaskUpdateRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new DailyTaskApi(configuration);

let taskId: string; // (default to undefined)
let dailyTaskUpdateRequest: DailyTaskUpdateRequest; //

const { status, data } = await apiInstance.apiDailyTaskTaskIdPut(
    taskId,
    dailyTaskUpdateRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dailyTaskUpdateRequest** | **DailyTaskUpdateRequest**|  | |
| **taskId** | [**string**] |  | defaults to undefined|


### Return type

**ApiResponseOfDailyTask**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

