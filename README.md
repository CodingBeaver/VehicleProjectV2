# Project.Service
.NET v4.7.2 API

List of routes: 

Base route: https://localhost:44380/api

### GET All Vehicle Makes

/make?{parameter}

Takes 5 parameters for sorting filtering and pagination(all optional)

   - string FilterString
   - string SortField( Make can ony be sorted by name and doesn't require this field) 
   - string SortDirection
   - int Pages
   - int PageSize(default size is 20, only included if Pages value is set) 

### GET Vehicle Make by id

  /make/id

### POST Vehicle Make

  /make

- body schema
    {
    "Name":"value"
    "Abrv":"value"
    }

### UPDATE Vehicle Make by Id

  /make/id
	
- schema is the same as the post route

### DELETE Vehicel Make by Id

  /make/id


### GET ALL Vehicel Models

  /model?{parameter}
  
- parameters are the same as the make route(SortField can be Name or MakeId)

### GET Vehicle Model by Id

  /model/id

### POST Vehicle Model

  /make

- body schema
    {
    "Name":"value",
    "MakeId":"value",
    "Abrv":"value"
    }

### UPDATE Vehicel Model by id

  /model/id

- schema is the same as the post route

### DELETE Vehicel Model by id

  /model/id

 NOTE: Id is stored as a Guid 







