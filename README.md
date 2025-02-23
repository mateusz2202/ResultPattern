# Result Pattern

## MessageResult
This class encapsulates a result that includes a message. It is used to return a status message along with the result of an operation.

### Properties:
- `Success` (bool): Indicates if the operation was successful.
- `Message` (string): Contains a message related to the result.

## Result
This class represents the outcome of an operation in a generic way.

### Properties:
- `Success` (bool): Indicates if the operation was successful.
- `Message` (List<string>): Contains error messages if the operation failed.
- `Data`T : Contains the result of the operation. 

## PaginationResult
This class represents the result of a paginated query.

### Properties:
- `Data` List<T>  A list of items on the current page.
- `TotalItems` (int): The total number of items across all pages.
- `PageNumber` (int): The current page number.
- `PageSize` (int): The number of items per page.
- `TotalPages` (int): The total number of pages.
- `HasPreviousPage` (bool)
- `HasNextPage` (bool)
