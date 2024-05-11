@payment
Feature: Payment Processing As a customer I want to be able to process payments  So that I can complete my purchase but have a error with a zero value


 @zeroPayment
  Scenario: Processing a payment request with zero payment
    Given I have a payment request with zero payment
    When I call the payment request with zero payment
    Then an exception should be thrown with the message "O valor do pagamento não pode ser 0."
