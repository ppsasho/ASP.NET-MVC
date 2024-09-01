# ***__Video Rental Online Store__***

## Welcome to the Video Rental Online Store!

This application allows users to browse, rent, and return movies with ease. Whether you're looking for the latest blockbuster or a classic film, our system is designed to make the rental process smooth and straightforward.

### Key Features:

1. **User Management**: 
   - Our system keeps track of users with essential details like name, age, and subscription status. Each user has a unique profile, which includes information like the subscription type and whether it's active.

2. **Movie Catalog**: 
   - Users can explore a diverse selection of movies, each with detailed information such as genre, language, availability, and age restrictions. The catalog is organized to help users find movies that match their preferences.

3. **Rental Transactions**: 
   - The application facilitates seamless rental transactions. Users can rent available movies, and the system will track their rentals, including the dates of rental and return.

### Application Models

- **User**: Represents each user in the system. Key details include:
  - `Id`, `FullName`, `Age`, `CardNumber`, `CreatedOn`, `IsSubscriptionExpired`, and `SubscriptionType`.

- **Movie**: Represents each movie in the catalog. Key details include:
  - `Id`, `Title`, `Genre`, `Language`, `IsAvailable`, `ReleaseDate`, `Length`, `AgeRestriction`, and `Quantity`.

- **Cast**: Represents individuals involved in the creation of a movie. Key details include:
  - `Id`, `Name`, `MovieId`, and `Part`.

- **Rental**: Tracks each rental transaction. Key details include:
  - `Id`, `MovieId`, `UserId`, `RentedOn`, and `ReturnedOn`.

### Enumeration Types:

- **SubscriptionType**: Defines the type of user subscription (`Monthly`, `Yearly`, etc.).
- **Genre**: Defines the genre of movies (`Action`, `Comedy`, `Drama`, etc.).
- **Language**: Defines the language of movies (`English`, `Spanish`, `French`, etc.).
- **Part**: Defines the roles of individuals in the movie (`Actor`, `Director`, `Camera`, etc.).

### Getting Started with the Application

- **User Login**: While traditional authentication is not used, users can identify themselves using their `CardNumber` or `Email`. Once logged in, user information is maintained for the session.

- **Viewing Movies**: Users can browse a list of all available movies, with options to filter by genre or language. Each movie's availability status is clearly displayed.

- **Movie Details**: Clicking on a movie title reveals detailed information, allowing users to learn more about the film before deciding to rent it.

- **Renting a Movie**: If a movie is available, users can rent it with a single click. The system automatically updates the movie's availability and tracks the rental.

- **Returning a Movie**: Users can easily return rented movies, which updates both their rental history and the movie's availability in the catalog.

---

This introduction provides a comprehensive overview of the application, giving new users a clear understanding of its features and how to interact with it.

### Using application

**Instructions to Run the Application:**

    *Prerequisites:*
        Visual Studio: Ensure you have Visual Studio installed.
        .NET Core 6.0: Your Visual Studio installation must include at least .NET Core 6.0.
        SQL Server Management Studio (SSMS): Make sure SSMS is installed and properly configured.

    Setting Up the Project:
        Open the solution in Visual Studio.
        In the Package Manager Console, select Storage as the default project.
        Run the following command to update the database and establish the connection with SSMS:  Update-Database
