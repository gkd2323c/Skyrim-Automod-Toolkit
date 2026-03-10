cmake_minimum_required(VERSION 3.24)

# ========================================
# Project Configuration
# ========================================
project(
    {{PROJECT_NAME}}
    VERSION {{VERSION_MAJOR}}.{{VERSION_MINOR}}.{{VERSION_PATCH}}
    LANGUAGES CXX
)

# ========================================
# Build Options
# ========================================
set(CMAKE_CXX_STANDARD 23)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)
set(CMAKE_INTERPROCEDURAL_OPTIMIZATION ON)
set(CMAKE_INTERPROCEDURAL_OPTIMIZATION_DEBUG OFF)

# MSVC-specific flags
if(MSVC)
    add_compile_options(
        /MP     # Multi-processor compilation
        /W4     # Warning level 4
        /WX     # Treat warnings as errors
        /permissive-    # Standards conformance
        /Zc:preprocessor    # Use conforming preprocessor
        /EHsc   # Exception handling
        /utf-8  # UTF-8 source files

        # Disable specific warnings
        /wd4068 # unknown pragma 'clang'
        /wd4189 # local variable is initialized but not referenced
        /wd4200 # nonstandard extension used : zero-sized array in struct/union
        /wd4201 # nonstandard extension used : nameless struct/union
        /wd4324 # structure was padded due to alignment specifier
    )
endif()

# ========================================
# Dependencies - Auto-downloaded via FetchContent
# ========================================
include(FetchContent)

message(STATUS "Fetching CommonLibSSE-NG (this may take a few minutes on first build)...")
FetchContent_Declare(
    CommonLibSSE
    GIT_REPOSITORY https://github.com/CharmedBaryon/CommonLibSSE-NG.git
    GIT_TAG v3.7.0
    GIT_SHALLOW TRUE
)
FetchContent_MakeAvailable(CommonLibSSE)

# ========================================
# Plugin Configuration
# ========================================
set(PLUGIN_NAME "${PROJECT_NAME}")
set(PLUGIN_AUTHOR "{{AUTHOR}}")
set(PLUGIN_VERSION "${PROJECT_VERSION}")

# ========================================
# Source Files
# ========================================
set(SOURCES
    src/main.cpp
    src/plugin.cpp
    src/papyrus.cpp
)

set(HEADERS
    src/plugin.h
    src/papyrus.h
)

# ========================================
# Build Target
# ========================================
add_library(${PROJECT_NAME} SHARED
    ${SOURCES}
    ${HEADERS}
)

target_compile_definitions(${PROJECT_NAME} PRIVATE
    PLUGIN_NAME="${PLUGIN_NAME}"
    PLUGIN_AUTHOR="${PLUGIN_AUTHOR}"
    PLUGIN_VERSION="${PLUGIN_VERSION}"
)

target_include_directories(${PROJECT_NAME} PRIVATE
    ${CMAKE_CURRENT_SOURCE_DIR}/src
)

target_link_libraries(${PROJECT_NAME} PRIVATE
    CommonLibSSE::CommonLibSSE
)

# ========================================
# Output Configuration
# ========================================
set_target_properties(${PROJECT_NAME} PROPERTIES
    OUTPUT_NAME "${PLUGIN_NAME}"
    SUFFIX ".dll"
)

# ========================================
# Post-Build: Copy to Skyrim Data/SKSE/Plugins
# ========================================
# Uncomment and set your Skyrim path to auto-deploy after build:
# set(SKYRIM_PATH "C:/Program Files (x86)/Steam/steamapps/common/Skyrim Special Edition")
# add_custom_command(
#     TARGET ${PROJECT_NAME} POST_BUILD
#     COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:${PROJECT_NAME}> "${SKYRIM_PATH}/Data/SKSE/Plugins/"
#     COMMAND ${CMAKE_COMMAND} -E echo "Deployed to: ${SKYRIM_PATH}/Data/SKSE/Plugins/"
# )
