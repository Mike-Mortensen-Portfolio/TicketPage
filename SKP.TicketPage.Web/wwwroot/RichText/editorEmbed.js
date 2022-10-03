InlineEditor
    .create(document.querySelector('.editor'), {

        licenseKey: '',



    })
    .then(editor => {
        window.editor = editor;




    })
    .catch(error => {
        console.error('Oops, something went wrong!');
        console.error('Please, report the following error on https://github.com/ckeditor/ckeditor5/issues with the build id and the error stack trace:');
        console.warn('Build id: g0odbkmz7czj-qv4rmsnwwei0');
        console.error(error);
    });

document.querySelector("#submit").addEventListener('click', () => {
    const editorData = editor.getData();

    document.querySelector("#editorData").value = editorData;
})