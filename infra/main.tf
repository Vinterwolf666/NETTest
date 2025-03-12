provider "google" {
  credentials = var.credentials # Usa la clave JSON de la cuenta de servicio
  project     = var.project_id
  region      = "us-central1"
}

variable "project_id" {
  default = "spiderops"
}

resource "google_container_cluster" "primary" {
  name     = "my-gke-cluster"
  location = "us-central1"

  remove_default_node_pool = true
  initial_node_count       = 1

  node_config {
    machine_type = "e2-medium"
    disk_size_gb = 10
    oauth_scopes = [
      "https://www.googleapis.com/auth/cloud-platform"
    ]
  }
}

resource "google_artifact_registry_repository" "repo" {
  provider      = google
  project       = var.project_id
  location      = "us-central1"
  repository_id = "my-repo"
  format        = "DOCKER"
}
