#!/usr/bin/env bash

set -eu

cd `dirname $0`

FSIARGS=""
OS=${OS:-"unknown"}
FSIARGS="--fsiargs -d:MONO"

mono .paket/paket.bootstrapper.exe

mozroots --import --sync --quiet
mono .paket/paket.exe restore

[ ! -e build.fsx ] && mono .paket/paket.exe update
[ ! -e build.fsx ] && mono packages/FAKE/tools/FAKE.exe init.fsx
mono packages/FAKE/tools/FAKE.exe "$@" $FSIARGS build.fsx