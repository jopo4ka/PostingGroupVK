using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
namespace PostingGroupVK
{
    public partial class Form1 : Form
    {
        public VkApi vk = new VkApi();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;        // email или телефон
            string pass = textBox2.Text;         // пароль для авторизации
            Settings scope = Settings.All;      // Приложение имеет доступ к друзьям
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = 6116967,
                Login = email,
                Password = pass,
                Settings = scope
            });

            if (vk.IsAuthorized)
            {
                var info = vk.Account.GetProfileInfo();
                authorizeBox.Text = info.FirstName + " " + info.LastName;
                authPanel.Visible = false;
            }else
            {
                authorizeBox.Text = "Authorised filed, please try again!";
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            //onClick search button
            if (vk.IsAuthorized)
            {
                int cnt = 0;
                var groups = vk.Groups.Search(new GroupsSearchParams{ Query = txtSrch.Text, Count=100 });
                foreach (var group in groups)
                {
                    var getted = vk.Groups.GetById(null, group.Id.ToString(), GroupsFields.CanPost | GroupsFields.CanSeelAllPosts | GroupsFields.MembersCount).FirstOrDefault() ;
                    bool canPost = getted.CanPost;
                    bool pblcGrp = getted.CanSeelAllPosts;
                    bool valid;
                    if (getted.MembersCount > membersCnt.Value){ valid = true; }
                                              else { valid = false; }
                    if (canPost && pblcGrp && valid)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[cnt].Cells[0].Value = group.Name;
                        dataGridView1.Rows[cnt].Cells[1].Value = canPost;
                        dataGridView1.Rows[cnt].Cells[2].Value = group.Id;
                        try
                        {
                            PhotoGetAlbumsParams pgap = new PhotoGetAlbumsParams
                            {
                                OwnerId = 0 - group.Id,

                            };
                            var albums = vk.Photo.GetAlbums(pgap);
                            int albCnt = 0;
                            foreach (var album in albums)
                            {
                                DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
                                secondColumn.HeaderText = "Name " + albCnt;
                                secondColumn.Name = albCnt.ToString();
                                if (dataGridView1.ColumnCount <= albCnt + 3)
                                {
                                    dataGridView1.Columns.Add(secondColumn);
                                }
                                dataGridView1.Rows[cnt].Cells[albCnt + 3].Value = album.Id; 
                                albCnt++;
                            }
                        }
                        catch 
                        {
                            Debugger.Log(1, "Exception", "Exception");
                        }
                        finally {
                            cnt++;
                        }
                    }
                }
            }
            
        }

        private void btnSnd_Click(object sender, EventArgs e)
        {
            string[] rf = new string[4];
            var wc = new WebClient();

            if (dataGridView1.ColumnCount > 3)
            {
                for (int row = 0; dataGridView1.RowCount - 1 > row; row++)
                {
                    var groupId = long.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString());
                    if (albumID.Text != "")
                    {
                        var photos = vk.Photo.Get(new PhotoGetParams
                        {
                            Count = 4,
                            AlbumId = PhotoAlbumType.Id(int.Parse(albumID.Text)),
                            OwnerId = vk.UserId
                        });
                        WallPostParams wpp = new WallPostParams
                        {
                            Message = msgWall.Text,
                            OwnerId = 0 - groupId,
                            Attachments = photos
                        };
                        vk.Wall.Post(wpp);
                    }
                    else {
                        WallPostParams wpp = new WallPostParams
                        {
                            Message = msgWall.Text,
                            OwnerId = 0 - groupId
                        };
                        vk.Wall.Post(wpp);
                    }

                    for (int cel = 3; dataGridView1.ColumnCount - 1 > cel && dataGridView1.Rows[row].Cells[cel].Value != null; cel++)
                    {
                        if (dataGridView1.Rows[row].Cells[cel].Value.ToString() != "")
                        {
                            try
                            {
                                long albumId = long.Parse(dataGridView1.Rows[row].Cells[cel].Value.ToString());
                                var ups = vk.Photo.GetUploadServer(albumId, groupId);
                                rf[0] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, Application.StartupPath + @"\file1.jpg"));
                                rf[1] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, Application.StartupPath + @"\file2.jpg"));
                                rf[2] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, Application.StartupPath + @"\file3.jpg"));
                                rf[3] = Encoding.ASCII.GetString(wc.UploadFile(ups.UploadUrl, Application.StartupPath + @"\file4.jpg"));
                                for (int i = 0; i < 4; i++)
                                {
                                    var sPhotos = vk.Photo.Save(new PhotoSaveParams
                                    {
                                        SaveFileResponse = rf[i],
                                        GroupId = groupId,
                                        AlbumId = albumId
                                    });
                                    Thread.Sleep(500);
                                } // for (int i = 0; i < 4; i++)
                            }
                            catch
                            {
                                Debugger.Log(1, "Exception", "Exception");
                            }
                            Thread.Sleep(1000 * (int)numKD1.Value); // КД между альбомами
                        } // for (int cel = 3; dataGridView1.ColumnCount - 1 > cel && dataGridView1.Rows[row].Cells[cel].Value != null; cel++)
                        Thread.Sleep(1000 * (int)numKD2.Value); // КД между группами
                    }
                } //  for (int row = 0; dataGridView1.RowCount - 1 > row; row++)
            }  //  if (dataGridView1.ColumnCount > 3)

        }

        private void btn_cls_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void impBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = openFileDialog1.FileName;
            string[] arrstr = File.ReadAllLines(fileName);
            int mCnt = 0;
            if (vk.IsAuthorized)
            {
                foreach (string id in arrstr)
                {
                    var getted = vk.Groups.GetById(null, id, GroupsFields.CanPost | GroupsFields.CanSeelAllPosts | GroupsFields.MembersCount).FirstOrDefault();
                    bool canPost = getted.CanPost;
                    bool pblcGrp = getted.CanSeelAllPosts;
                    bool valid;
                    valid = (getted.MembersCount > membersCnt.Value);

                    if(valid && canPost && pblcGrp)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[mCnt].Cells[0].Value = getted.Name;
                        dataGridView1.Rows[mCnt].Cells[1].Value = canPost;
                        dataGridView1.Rows[mCnt].Cells[2].Value = getted.Id;
                        try
                        {
                            PhotoGetAlbumsParams pgap = new PhotoGetAlbumsParams
                            {
                                OwnerId = 0 - getted.Id,

                            };
                            var albums = vk.Photo.GetAlbums(pgap);
                            int albCnt = 0;
                            foreach (var album in albums)
                            {
                                DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
                                secondColumn.HeaderText = "Name " + albCnt;
                                secondColumn.Name = albCnt.ToString();
                                if (dataGridView1.ColumnCount <= albCnt + 3)
                                {
                                    dataGridView1.Columns.Add(secondColumn);
                                }
                                dataGridView1.Rows[mCnt].Cells[albCnt + 3].Value = album.Id;
                                albCnt++;
                            }
                        }
                        catch
                        {
                            Debugger.Log(1, "Exception", "Exception");
                        }
                        finally
                        {
                            mCnt++;
                        }

                    }

                }
            }
        }
    }
}
