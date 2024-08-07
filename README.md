Mock Talks API

Edits:
3/19/24: Created the API files, no functionality or connected database yet.
3/22/24: Prepared the API for Database connection.
3/24/24: Added the database connection, set up basic login system and tables. Will most liekly be modified in the future based on need.
4/4-5/24: Implemented a models, services, and controller for a user's profile data. Untested, might not work.
4/8/24: The profile data's endpoints are fully functional. How the code was set up before it was tested didn't work, so I made the necessary modifications.
4/9/24: The messaging endpoints are created, but have not been tested. Will look into websockets to make the messaging live.
4/10/24 pt1: Created an endpoint to update a user's password if they forgot. May have broken many things.
4/10/24 pt2: Created a few endpoints for the schedule. This is going to be messy to implement.
4/11/24: Dropped tables, allowing for the new controllers to have tables. Changing passwords endpoint working.
4/26/24: Added some schedule endpoints.
4/30/24: Made model data non-nullable.
5/9/24: Added most of the logic for the real time messaging components. Will probably need more in the future.
5/10/24: Added an ID to the messaging connect model.
5/15/24: Have messaging backend completely working. Adding ID was one of few things that broke it, along with having essential code commented out :)
5/17/24: Messaging is now fully hooked up to the frontend. Everything works as intended here.
5/21/24: Added parenthesis for messaging retrieval for sender and receiver IDs.
5/23/24: Added endpoint for profile controller, get all profiles.