#!/bin/bash

# Publish the .NET application for multiple runtimes
PROJECT_PATH="./src/GitHubActivity.CLI/GitHubActivity.CLI.csproj"
OUTPUT_BASE_PATH="./publish"
RUNTIMES=("win-x64" "linux-x64" "osx-x64" "osx-arm64")
for RUNTIME in "${RUNTIMES[@]}"; do
    OUTPUT_PATH="$OUTPUT_BASE_PATH/$RUNTIME"
    echo "Publishing .NET application for $RUNTIME..."
    dotnet publish "$PROJECT_PATH" -c Release -r "$RUNTIME" -o "$OUTPUT_PATH" \
        -p:PublishSingleFile=true \
        -p:IncludeNativeLibraries=true \
        -p:PublishReadyToRun=true \
        -p:DebugType=embedded \
        --self-contained=true
    echo "Publish completed for $RUNTIME! Output directory: $OUTPUT_PATH"
done

# Build a Debian package
PACKAGE_NAME="ghact"
VERSION="1.0.0"
ARCHITECTURE="amd64"
MAINTAINER="Muhammed Nilifirka <muhammednlfrk@gmail.com>"
HOMEPAGE="https://github.com/muhammednlfrk/ghact"
DESCRIPTION="GitHub Activity Tracker"
SRC_DIR="publish/linux-x64"
OUTPUT_DIR="publish/linux-x64/deb"
DEB_DIR="${OUTPUT_DIR}/${PACKAGE_NAME}-${VERSION}"
CONTROL_DIR="${DEB_DIR}/DEBIAN"
echo "Cleaning previous builds..."
rm -rf ${DEB_DIR}
echo "Creating directory structure..."
mkdir -p ${CONTROL_DIR}
mkdir -p ${DEB_DIR}/usr/local/bin
echo "Creating control file..."
cat << EOF > ${CONTROL_DIR}/control
Package: ${PACKAGE_NAME}
Version: ${VERSION}
Architecture: ${ARCHITECTURE}
Maintainer: ${MAINTAINER}
Installed-Size: 1024
Section: utils
Priority: optional
Homepage: ${HOMEPAGE}
Description: ${DESCRIPTION}
EOF
echo "Copying application files..."
cp -r ${SRC_DIR}/* ${DEB_DIR}/usr/local/bin/
echo "Building .deb package..."
dpkg-deb --build ${DEB_DIR} ${OUTPUT_DIR}
echo "Debian package has been created at ${OUTPUT_DIR}/${PACKAGE_NAME}-linux-x64-${VERSION}.deb"
