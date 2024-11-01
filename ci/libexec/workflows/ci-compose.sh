#!/usr/bin/env bash
# shellcheck disable=SC2155

###
# Compose the project's artifacts, e.g., compiled binaries, Docker images.
#   This workflow performs all steps required to create the project's output.
#
#   This script expects a CICEE CI library environment (which is provided when using 'cicee lib exec').
#   For CI library environment details, see: https://github.com/JeremiahSanders/cicee/blob/main/docs/use/ci-library.md
#
# How to use:
#   Modify the "ci-compose" function, below, to execute the steps required to produce the project's artifacts.
###

set -o errexit  # Fail or exit immediately if there is an error.
set -o nounset  # Fail if an unset variable is used.
set -o pipefail # Fail pipelines if any command errors, not just the last one.

function ci-compose() {
  printf "Composing build artifacts...\n\n"

  function createDocs() {
    cd "${PROJECT_ROOT}"
    dotnet tool restore
    local sourcePath="${BUILD_UNPACKAGED_DIST}/ProjectUsNormalizer.dll"
    local outputPath="${BUILD_DOCS}/md"
    dotnet xmldocmd "${sourcePath}" "${outputPath}" \
      --namespace "ProjectUsNormalizer" \
      --source "https://github.com/ica-carealign/project-us-normalizer/tree/main/src" \
      --newline lf \
      --visibility public
  }

  ci-dotnet-publish \
    -p:GenerateDocumentationFile=true \
    --framework netstandard2.0 &&
    ci-dotnet-pack \
      -p:GenerateDocumentationFile=true &&
    createDocs

  printf "Composition complete.\n"
}

export -f ci-compose