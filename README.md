# NXT33_ONL3_SWD5_S5_PlayLocal
**For More Details Please open the detailed Business Plan Before Reaching out**

---

# PlayLocal — Sports Venue Booking Platform

## Overview

PlayLocal is a full-stack sports venue booking web application designed to connect **players** with nearby sports venues and enable **venue owners** to efficiently manage their facilities. The platform supports venue discovery, court management, working hours scheduling, and secure role-based access, all built on a scalable .NET architecture.

The system focuses on clean separation between presentation, business logic, and data access layers, ensuring maintainability and extensibility.

---

## Features

### 1. Role-Based Authentication System

* Secure login and session management
* Two distinct user roles:

  * **Owner**: Manages venues and courts
  * **Player**: Browses venues and makes bookings
* Session-based authorization to protect restricted actions
* Automatic redirection for unauthorized access

---

### 2. Venue Management (Owner Panel)

* Add, edit, and delete sports venues
* Venue details include:

  * Name
  * Address
  * Description
  * Contact phone number
  * Google Maps location link
  * Equipment rental availability
* Owner-only access to assigned venues
* Clean dashboard for managing multiple venues

---

### 3. Working Hours Scheduling

* Configure venue working hours for all days of the week
* Separate open and close times per day
* Automatic replacement of old working hours on update
* Structured validation to ensure data consistency

---

### 4. Court Management

* Add and manage courts within each venue
* Courts linked directly to their respective venues
* Support for multiple courts per venue
* Designed to scale for future sport-specific court configurations

---

### 5. Booking System (Player Side)

* Browse available venues
* View venue details, working hours, and courts
* Designed booking flow ready for:

  * Date & time selection
  * Availability checking
  * Booking confirmation
* Architecture supports future payment integration

---

### 6. Responsive UI & User Experience

* Fully responsive layout using Bootstrap
* Mobile-friendly navigation and forms
* Clean dashboards for owners and players
* Consistent visual design across all pages

---

### 7. Data Integrity & Validation

* Server-side validation using ViewModels
* Strong separation between:

  * ViewModels
  * Domain Models
  * Database entities
* Controlled CRUD operations through repositories
* Safe deletion with dependency handling (venues, courts, working hours)

---

## Technical Implementation

### Frontend

* **HTML5**: Semantic and accessible structure
* **CSS3**:

  * Custom styling
  * Responsive layouts
  * UI consistency across dashboards
* **Bootstrap 5**:

  * Grid system
  * Forms and components
* **JavaScript**:

  * UI interactions
  * Client-side enhancements

---

### Backend

* **ASP.NET Core MVC**
* **C#**
* **Entity Framework Core**
* **MS SQL Server**
* Repository pattern for data access
* Layered architecture:

  * Presentation Layer (PL)
  * Business Logic Layer (BLL)
  * Data Access Layer (DAL)

---

### Architecture

* MVC pattern with strong ViewModel usage
* Repository pattern for database operations
* Clear separation of concerns
* Scalable design ready for feature expansion
* Session-based authentication and authorization

---

## Usage Instructions

### Registration & Login

* Users log in based on their assigned role
* Session data controls access and navigation

---

### Owner Workflow

1. Log in as **Owner**
2. Access Owner Dashboard
3. Add a new venue
4. Configure venue working hours
5. Manage courts
6. Edit or delete venues as needed

---

### Player Workflow

1. Log in as **Player**
2. Browse available venues
3. View venue details and schedules
4. Proceed with booking flow

---

## Database Structure

* Users
* Venues
* Venue Working Hours
* Courts
* Bookings (extensible for future features)

Relational integrity enforced through foreign keys and controlled deletion logic.

---

## Dependencies

* Bootstrap 5
* Font Awesome
* Entity Framework Core
* SQL Server

---

## Browser Support

* Chrome (latest)
* Firefox (latest)
* Edge (latest)
* Safari (latest)
* Mobile Chrome & Safari

---

## Future Enhancements

* Online payment integration
* Real-time court availability
* Booking notifications (email/SMS)
* Admin analytics dashboard
* Ratings and reviews system

---

## Author

**Ezzeldin Omar**
Full-Stack .NET Developer

# Contact:
Please send an email to Book a meeting on the Teams link

**Email**: ezzeldinomar7@gmail.com

**Teams**:
https://teams.microsoft.com/l/meetup-join/19%3ameeting_NGQ3ZjBkZjYtNzU2Ny00ZTgxLWJiMjctOWQ3MWRjNmMwZDBk%40thread.v2/0?context=%7b%22Tid%22%3a%2277255288-5298-4ea5-81aa-a13e604c30ac%22%2c%22Oid%22%3a%2251848b57-47e3-4b28-8f71-c706c08277d9%22%7d
