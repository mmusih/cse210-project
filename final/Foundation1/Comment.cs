public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public override string ToString()
    {
        return $"{_commenterName}: {_commentText}";
    }
}
