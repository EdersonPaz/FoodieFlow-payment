provider "aws" {
  region = "us-east-1"
}

resource "aws_s3_bucket" "bucket" {
  bucket = "bucket-foodieFlow-pgm"
  tags = {
    Name        = "bucket-foodieFlowPgm"
    Environment = "Dev"
  }
}

resource "aws_sqs_queue" "queue" {
  name                      = "queue-foodieFlowPgm"
  delay_seconds             = 90
  max_message_size          = 2048
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10
}

resource "aws_sqs_queue" "dead-letter_queue" {
  name                      = "dlq-foodieFlowPgm"
  delay_seconds             = 90
  max_message_size          = 2048
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10

  redrive_policy = jsonencode({
    deadLetterTargetArn = aws_sqs_queue.dead-letter_queue.arn
    maxReceiveCount     = 3
  })
}

resource "aws_secretsmanager_secret" "secret" {
  name        = "secret_foodieFlowPgm"
  description = "Descrição do seu secret"
}

resource "aws_secretsmanager_secret_version" "secret_version" {
  secret_id     = aws_secretsmanager_secret.secret.id
  secret_string = jsonencode({
    bucket_name = aws_s3_bucket.bucket.bucket
    queue_name  = aws_sqs_queue.queue.name
    dlq_name    = aws_sqs_queue.dead-letter_queue.name
  })
}

provider "aws" {
  region = "us-west-2"
}

resource "aws_ecr_repository" "repository" {
  name = "meu-repositorio"
}

resource "aws_s3_bucket" "bucket" {
  bucket = "meu-bucket"
  acl    = "private"
}

resource "aws_ecs_cluster" "cluster" {
  name = "meu-cluster"
}

resource "aws_ecs_service" "service" {
  name            = "meu-servico"
  cluster         = aws_ecs_cluster.cluster.id
  task_definition = aws_ecs_task_definition.task.arn
  desired_count   = 1

  load_balancer {
    target_group_arn = aws_lb_target_group.group.arn
    container_name   = "meu-container"
    container_port   = 80
  }
}

resource "aws_lb" "lb" {
  name               = "meu-lb"
  internal           = false
  load_balancer_type = "application"
  security_groups    = [aws_security_group.group.id]
  subnets            = ["subnet-abcde012", "subnet-bcde012a", "subnet-fghi345a"]
}

resource "aws_lb_target_group" "group" {
  name     = "meu-grupo"
  port     = 80
  protocol = "HTTP"
  vpc_id   = "vpc-abcde012"
}

resource "aws_lb_listener" "listener" {
  load_balancer_arn = aws_lb.lb.arn
  port              = "80"
  protocol          = "HTTP"

  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.group.arn
  }
}
