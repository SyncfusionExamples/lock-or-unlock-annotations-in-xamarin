# Lock or unlock annotations in PDF [Xamarin]

This repository contains an example that demonstrates how to lock or unlock annotations dynamically using the Syncfusion® Xamarin.Forms PDF Viewer. It explains how annotation interaction can be controlled at runtime to support scenarios such as secure document viewing, review workflows, and role-based access control.

The sample focuses on managing existing annotations within a loaded PDF document without requiring the document to be reloaded or recreated.

## Overview

PDF annotations are commonly used for document review, collaboration, and feedback. While annotations enhance usability, many applications require restrictions on when and how annotations can be edited.

This project explains how to dynamically manage annotation interaction by locking and unlocking annotations after the document is loaded. This approach ensures documents remain interactive while protecting finalized or restricted content.

## Supported Platforms

This sample supports the following platforms:

- Android  
- iOS  
- UWP (Universal Windows Platform)

The annotation locking behavior is implemented consistently across all supported platforms.

## Key Features

The sample demonstrates dynamic control of annotation behavior at runtime:

- Locking and unlocking all annotations without reloading the document  
- Immediate enforcement of annotation restrictions  
- Flexible design that can be extended based on workflows or application logic  
- Support for advanced scenarios such as role-based or state-based restrictions  

## Prerequisites

Before running this sample, ensure the following are available:

- Visual Studio with Xamarin.Forms development support  
- Android SDK, Xcode, or UWP tooling depending on the target platform  
- A valid Syncfusion license (community license available for eligible users)  

## Understanding PDF Annotations

Annotations are interactive elements added to PDF documents for communication and feedback. Common annotation types include text markups, ink drawings, shapes, free-text notes, and stamps.

Each annotation includes metadata that controls its appearance and behavior. One important attribute is the lock state, which determines if the annotation can be modified.

## Meaning of Locking an Annotation

Locking an annotation prevents it from being moved, resized, edited, or deleted. This behavior is essential for protecting finalized remarks, approvals, or restricted feedback.

## Locking Annotations

All annotations in a document can be locked at once to enforce a read-only state. This is useful for finalized documents, signed records, or audit files. Locking can be applied immediately after the document loads.

## Unlocking Annotations

Annotations can be unlocked dynamically to allow editing when required. This enables workflows where documents transition between editable and non-editable states based on user actions or business rules.

## Selective Annotation Locking

Specific annotation types can be locked while others remain editable. For example, highlights may be locked while comments stay editable. This provides fine-grained control over document interaction.

## Role-Based Annotation Control

Annotation locking can be integrated with user roles. Administrators or reviewers may be allowed to edit annotations, while standard users may only view them. This is ideal for enterprise and compliance-driven applications.

## Dynamic Lock State Control

The lock state of annotations can be toggled at runtime without reloading the document. This allows UI controls to dynamically enable or disable annotation editing during the application lifecycle.

## Annotation Interaction Handling

The PDF Viewer provides events that detect user interaction with annotations. These events can be used to provide feedback when users attempt to edit locked annotations, improving clarity and usability.

## Conclusion

This repository demonstrates a flexible and reliable approach to managing PDF annotation interaction using the Syncfusion Xamarin.Forms PDF Viewer. By dynamically locking and unlocking annotations, applications can maintain document integrity while supporting structured collaboration and review workflows.

For more details, refer to the official Syncfusion [documentation](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/xamarin/overview) and [API reference](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfPdfViewer.XForms.html).
