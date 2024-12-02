# Lift
This project is an Elevator Control System developed using Blazor, Fusion for real-time state updates, and Entity Framework Core for data access. It simulates the behavior of an elevator, including floor requests, direction changes, and elevator state updates. The system supports a real-time interface that reflects the current elevator state as well as handles multiple requests.
Features
Real-time State Updates: Using the Fusion library, the elevator's current state (e.g., floor, direction, busy status) updates automatically in the UI.
Elevator Request: Users can request the elevator to a specified floor, and the system will handle the direction and floor change accordingly.
Database Integration: The elevator states and requests are stored in a database using Entity Framework Core.
Dynamic Floor Management: Users can select a floor (1 to 10), and the system will compute the elevator's movement in real-time.
