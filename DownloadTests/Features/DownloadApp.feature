Feature: DownloadApp

File download automation with Playwright

@tag1
Scenario: Download a file
	Given I am on the download page
	When I click the download button
	Then the file should be downloaded
