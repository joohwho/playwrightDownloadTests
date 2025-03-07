Feature: DownloadApp

File download automation with Playwright

@downloadApp
Scenario: Download a file
	Given I am on the "/download" Page
	When I click on the first File Link in the list
	Then the File should be Downloaded
