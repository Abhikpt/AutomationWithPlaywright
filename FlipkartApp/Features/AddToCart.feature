Feature: Product Purchase Flow

  @Regresion
  Scenario: User adds a product to cart from search results
    Given I navigate to Flipkart page
    And I login with username "test_user" and password "test_password"
    When I search for "iPhone 14"
    And I select the first product
    And I add the product to the cart
    Then I should see the product in the cart
