# Lock or unlock annotations in PDF [Xamarin]
This repo contains the example which demonstrates how to lock or unlock annotations dynamically using Syncfusion&reg; Xamarin.Forms PDF Viewer. It explains how annotation interaction can be controlled at runtime to meet real‑world application requirements such as secure document viewing, review workflows, and role‑based access.
The sample focuses on controlling existing annotations within a loaded PDF document without requiring the document to be reloaded or recreated.

## Overview
PDF annotations are commonly used for document review, collaboration, and feedback. While annotations improve usability, many applications require restrictions on when and how annotations can be edited.
This project explains how to manage annotation interaction dynamically by locking and unlocking annotations after the document is loaded. The approach ensures that documents remain interactive while protecting finalized or restricted content.
The solution is built using Syncfusion Xamarin.Forms PDF Viewer and is intended for mobile applications targeting Android and iOS.

## Key Features
The solution supports dynamic control of annotation behavior at runtime. All annotations present in the document can be locked or unlocked based on application logic.
The locking behavior takes effect immediately without reloading the PDF document. This ensures a smooth and responsive user experience.
The design is flexible and can be extended to apply restrictions based on annotation type, user role, or workflow state.

## Prerequisites
To use this sample, a Xamarin.Forms development environment must be set up in Visual Studio. Platform‑specific tools such as the Android SDK or Xcode are required depending on the target platform.
A valid Syncfusion license is required, and a free community license is available for eligible developers.

### Understanding PDF Annotations
Annotations are interactive objects added to PDF documents to convey information. Common annotation types include text markups, ink drawings, shapes, free‑text notes, and stamps.
Each annotation contains metadata that defines its appearance and behavior. One key property is the lock state, which determines whether the annotation can be edited by the user.

### Meaning of Locking an Annotation
Locking an annotation prevents users from modifying it. When locked, an annotation cannot be moved, resized, edited, or deleted.
This behavior is essential in scenarios where annotations represent finalized remarks, approvals, or protected feedback.

### Locking Annotations
All annotations within a document can be locked simultaneously to ensure complete read‑only behavior. This is useful for finalized documents, signed files, or audit records where changes must be prevented.
Locking can be applied immediately after the document finishes loading, ensuring users never interact with annotations in an unintended state.

### Unlocking Annotations
Annotations can be unlocked dynamically to allow editing when required. This enables workflows where documents transition between editable and read‑only states based on business rules or user actions.
Unlocking does not require the document to be reloaded and takes effect immediately.

### Selective Annotation Locking
Instead of locking all annotations, specific annotation types can be restricted while others remain editable. This allows advanced control scenarios, such as keeping comments editable while locking highlights or shapes.
Selective locking ensures flexibility while maintaining document control.

### Role‑Based Annotation Control
Annotation locking can be integrated with user roles. For example, administrators or reviewers may have permission to edit annotations, while standard users may only view them.
This approach is suitable for enterprise applications that require permission‑based document interaction.

### Dynamic Lock State Control
The lock state of annotations can be toggled dynamically at runtime. This allows applications to provide user interface controls that enable or disable annotation editing without restarting the application or reloading the document.
Such behavior is useful in review and approval workflows.

### Annotation Interaction Handling
The PDF Viewer raises events when users interact with annotations. These events can be used to detect attempts to edit locked annotations and provide feedback to the user.
Clear feedback improves usability and helps users understand document restrictions.

### Conclusion
This repository demonstrates a practical and flexible approach to managing PDF annotation interaction using the Syncfusion Xamarin.Forms PDF Viewer. By dynamically locking and unlocking annotations, applications can enforce document integrity while still supporting controlled collaboration and review processes.
The techniques described here integrate seamlessly into real‑world mobile applications and can be adapted to various architectural patterns and workflow requirements. This makes annotation locking an effective solution for balancing usability, security, and control in PDF‑based Xamarin.Forms applications.

## Blog reference
[Easily Lock and Unlock Annotations Using Xamarin.Forms PDF Viewer](https://www.syncfusion.com/blogs/post/lock-and-unlock-annotations-using-xamarin-forms-pdf-viewer.aspx)
