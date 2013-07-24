Feature: Music Catalogue

Background: 
	Given I have the following items in the catalogue
		| Title                   | Artist     |
		| Dark Side of The Moon   | Pink Floyd |
		| Smells Like Teen Spirit | Nirvana    |
		| Live at the Acropolis   | Yanni      |

Scenario: Search by title
	When I search the title for the word 'moon'
	Then I should get 'Dark Side of The Moon' by 'Pink Floyd'

Scenario: Search without result
	When I search the title for the word 'baby'
	Then I should get an empty response

@ignore
Scenario Outline: Search by artist
	When I search artists for '<search string>'
	Then I should get '<title>' by '<artist>'
Examples: 
	| search string | title                 | artist     |
	| yanni         | Live at the Acropolis | Yanni      |
	| pink          | Dark Side of The Moon | Pink Floyd |