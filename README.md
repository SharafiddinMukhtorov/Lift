# Lift

This project is an Elevator Control System developed using Blazor, Fusion for real-time state updates, and Entity Framework Core for data access. It simulates the behavior of an elevator, including floor requests, direction changes, and elevator state updates. The system supports a real-time interface that reflects the current elevator state as well as handles multiple requests.

## Features

### Real-time State Updates
- Using the Fusion library, the elevator's current state (e.g., floor, direction, busy status) updates automatically in the UI.

### Elevator Request
- Users can request the elevator to a specified floor, and the system will handle the direction and floor change accordingly.

### Database Integration
- The elevator states and requests are stored in a database using Entity Framework Core.

### Dynamic Floor Management
- Users can select a floor (1 to 10), and the system will compute the elevator's movement in real-time.

## Technologies Used

- **Blazor Server**: For building the interactive web UI.
- **Fusion**: For real-time state management and automatic UI updates.
- **Entity Framework Core**: For ORM and database management.
- **PostgreSQL**: For storing elevator states and requests.

## Project Screenshots

### Elevator Control UI
- ![image](https://github.com/user-attachments/assets/9c320a34-e75a-41bb-95e4-860019f6c2d4)
- ![image](https://github.com/user-attachments/assets/6d4ccd11-8a23-4cfa-9d53-f902f83a99d0)
![image](https://github.com/user-attachments/assets/608f6c7e-586f-458e-9c3c-f8ee6df51c35)

