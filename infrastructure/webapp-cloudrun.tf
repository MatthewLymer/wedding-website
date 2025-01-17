resource "google_cloud_run_service" "default" {
  name = "webapp-service"
  location = "us-central1" # cloud-run does not work in Canada yet

  autogenerate_revision_name = true

  template {
    spec {
      containers {
        image = "gcr.io/matthewlymer-dioneandmatthew/webapp:latest"
        ports {
          container_port = 5000
        }
        env {
          name = "WW_PORT"
          value = "5000"
        }
        env {
          name = "WW_GOOGLE_API_KEY"
          value = var.WW_GOOGLE_API_KEY
        }
      }
    }
  }

  traffic {
    percent = 100
    latest_revision = true
  }
}

data "google_iam_policy" "noauth" {
  binding {
    role = "roles/run.invoker"
    members = [
      "allUsers",
    ]
  }
}

resource "google_cloud_run_service_iam_policy" "noauth" {
  location = google_cloud_run_service.default.location
  project = google_cloud_run_service.default.project
  service = google_cloud_run_service.default.name
  policy_data = data.google_iam_policy.noauth.policy_data
}

resource "google_cloud_run_domain_mapping" "default" {
  location = "us-central1"
  name = "dioneandmatthew.com"

  metadata {
    namespace = local.project.id
  }

  spec {
    route_name = google_cloud_run_service.default.name
  }
}

resource "google_cloud_run_domain_mapping" "www" {
  location = "us-central1"
  name = "www.dioneandmatthew.com"

  metadata {
    namespace = local.project.id
  }

  spec {
    route_name = google_cloud_run_service.default.name
  }
}

output "url" {
  value = google_cloud_run_service.default.status[0].url
}