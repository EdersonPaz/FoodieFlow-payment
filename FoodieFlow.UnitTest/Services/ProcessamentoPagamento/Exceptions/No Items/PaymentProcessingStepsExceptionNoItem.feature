@payment
Feature: Payment Processing As a customer I want to be able to process payments So that I can complete my purchase but have a error

 @exception
  Scenario: Processing a payment request with no items
    Given I have a payment request with no items
    When I call the payment request error
    Then an exception should be thrown
