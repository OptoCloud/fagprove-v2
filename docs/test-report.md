# Test report

## Introduction

This document describes the results of the testing phase of this project.

## Automated testing

I do automated build testing with GitHub actions and Code Quality checks with Github CodeQL.

Thes build tests are run on every push to the master branch, and CodeQL is ran weekly.

## Manual testing

In the start phase of the project I did manual testing of the website with Chrome browser.

I tested the website's responsiveness by using the developer tools to simulate different screen sizes and tried out all the preset screen sizes.

To test the website's functionality I tried out the following user stories:

- As a user I want to:
  - View the landing page
  - Navigate to the login page from any page
  - Navigate to the registration page from any page
  - Register a new account
  - Be redirected to the login page after registering
  - Login to a previously registered account
  - Be redirected to the home page after logging in
  - View the home page
  - Be redirected to the home page if I try to access the login, registration or home page while being logged in
  - Be redirected to the login page if I try to access the home page without being logged in
  - Logout from the home page
  - Click on the logo to go to the home page from any page
  - Create a new note from the home page
  - View a note from the home page
  - Search for a note from the home page
  - Naviage to a note from the home page
  - Edit a note from the note page
  - Delete a note from the note page
  - Change a note's directory from the note page
  - Navigate to the home page from the note page
  - Stay logged in after refreshing the page
  - Stay logged in after reopening the browser

I also did testing to make sure the following security features work:

- A user can't access the home page without being logged in
- A user can't access the login, registration or home page while being logged in
- A user can't load a note that doesn't belong to them
- A user can't edit a note that doesn't belong to them
- A user can't delete a note that doesn't belong to them
- A user can't change a note's directory if the note doesn't belong to them
- It is difficult for a user to perform timing attacks to guess the password of another user

## Results

All the automated tests passed.

All the manual tests passed.

All the security features work as intended.

The production envronment is broken, but the development environment works as intended.

The fix for this is known, but I don't have time to fix it before the deadline.
