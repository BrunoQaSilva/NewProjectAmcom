Feature: Formulario

@mytag
	Scenario: Fill out the first form
		Given I, navigate application
		When fill in the textbox of the form 
		| Nome  | SobreNome | Telefone  |
		| Bruno | Rocha     | 859999992 |
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 5 seconds
		And I Click Enviar Button
		And I wait for 5 seconds
		Then App return mensage confirm
		And I closed the popup
		And Wait to confirm 5 seconds close

	Scenario: Fill out the first form just Nome and Sobre Nome
		Given I, navigate application
		When fill in the textbox of the form reduced
		| Nome  | SobreNome |
		| Bruno | Rocha     | 
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 5 seconds
		And I Click Enviar Button
		And I wait for 5 seconds
		Then App return mensage confirm
		And I closed the popup
		And Wait to confirm 5 seconds close


	Scenario: Fill out the first form just Nome
		Given I, navigate application
		When fill in the textbox of the form most reduced
		| Nome  |
		| Bruno |
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 5 seconds
		And I Click Enviar Button
		And I wait for 5 seconds
		Then App return mensage confirm
		And I closed the popup
		And Wait to confirm 5 seconds close


	Scenario: Select a color Blue
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color blue
		And I wait for 5 seconds
		Then The element id "xpath=/html/body/div/div[3]" with the color "rgb(0, 0, 255)"

	Scenario: Select a color Yellow
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color Yellow
		And I wait for 5 seconds
		Then The element id "xpath=/html/body/div/div[3]" with the color "rgb(255, 255, 0)"

	Scenario: Select a color Red
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color Red
		And I wait for 5 seconds
		Then The element id "xpath=/html/body/div/div[3]" with the color "rgb(255, 0, 0)"


	Scenario: Click in Saudaçao button
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		Then The app returns a greeting message
		And Wait to confirm 5 seconds close

	@negativescenarie
	Scenario: Select a color other than the one shown
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color Red
		And I wait for 5 seconds
		Then The element id "xpath=/html/body/div/div[3]" with the color "rgb(255, 255, 0)"

	Scenario: Send empty form
		Given I, navigate application
		When I wait for 2 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I Click Enviar Button
		And I wait for 2 seconds
		Then App return mensage confirm
		And I closed the popup
		And Wait to confirm 5 seconds close









