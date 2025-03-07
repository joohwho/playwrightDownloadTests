Feature: UploadApp

File upload automation with Playwright

@uploadApp
Scenario: Upload a file
	Given I am on the "/upload" Page
	And I select the "FileTest.txt" File to upload
	When I click on the Upload button
	Then the "FileTest.txt" File should be Uploaded

